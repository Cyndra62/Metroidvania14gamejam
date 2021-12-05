using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    private PlayerCollision _playerCollision;
    private PlayerControls controls;

    private Rigidbody2D _rb;

    [Header ("Movement Variables")]
    [SerializeField] private float _speed;
    [SerializeField] private float _slideSpeed;
    [SerializeField] private float _jumpVelocity;
    [SerializeField] private float _wallJumpVelocityX;
    [SerializeField] private float _wallJumpVelocityY;

    [Header ("Dash Variables")]
    [SerializeField] private float _dashDistance = 20f;
    [SerializeField] private float _dashLinearDrag = 7.5f;
    [SerializeField] private float _dashDuration = 0.3f;
    [SerializeField] private float _dashCooldown = .75f;
    private float _nextDash = 0;
    private bool canDash = true;
    private bool isDashing = false;

    [Header ("Booleans")]
    [SerializeField] public bool _isDoubleJump = true;
    [SerializeField] private bool _pushingWall = false;
    [SerializeField] public bool _facingRight = true;
    [SerializeField] public bool _wallJump = false;
    [SerializeField] public int _leftOrRight;
    [SerializeField] public bool stopInput;

    [Header("Animation")]
    public Animator anim;

    [Header("Gate System")]
    public string areaTransitionName;

    private Vector2 dir = Vector2.zero;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }

        }
        controls = new PlayerControls();
        DontDestroyOnLoad(gameObject);
    }

    private void Start() 
    {
        stopInput = false;
        _rb = GetComponent<Rigidbody2D>();

        _playerCollision =GetComponent<PlayerCollision>();
        controls.PControls.Dash.performed += ctx => { if (_nextDash <= Time.time && canDash && PlayerPrefs.GetInt("DashEnabled", 0) == 1) StartCoroutine(Dash()); };
        controls.PControls.Jump.performed += ctx =>
        {
            if (_playerCollision._onGround)
            {
                Jump(Vector2.up, false);
            }
            else if (!_playerCollision._onGround && _isDoubleJump == true && _pushingWall == false)
            {
                Jump(Vector2.up, true);
            }

            if (_pushingWall == true && !_playerCollision._onGround)
            {
                _wallJump = true;
                Invoke("CancelWallJump", 0.2f);
            }
        };
        controls.PControls.Movement.performed += ctx => dir = ctx.ReadValue<Vector2>();
        controls.PControls.Movement.canceled += ctx => dir = Vector2.zero;
    }

    private void Update()
    {
        if (!stopInput)
        {
            //float x = Input.GetAxis("Horizontal");
            //float y = Input.GetAxis("Vertical");
            //Vector2 dir = new Vector2(x, y);
            Walk(dir);

            // Dash
            if (_playerCollision._onGround)
            {
                canDash = true;
            }
            // End Dash

            if (_playerCollision._onWall && !_playerCollision._onGround && _pushingWall == true)
            {
                WallSlide();
            }
            if (_playerCollision._onGround)
            {
                _isDoubleJump = true;
                _wallJump = false;
            }

            if ((_rb.velocity.x > 0 && _playerCollision._onRightWall) || (_rb.velocity.x < 0 && _playerCollision._onLeftWall))
            {
                _pushingWall = true;

            }
            else
            {
                _pushingWall = false;
            }

            if (_wallJump)
            {
                WallJump();
            }

            //if (Input.GetButtonDown("Jump"))
            //{
            //    if (_playerCollision._onGround)
            //    {
            //        Jump(Vector2.up, false);
            //    }
            //    else if (!_playerCollision._onGround && _isDoubleJump == true && _pushingWall == false)
            //    {
            //        Jump(Vector2.up, true);
            //    }
            //}


            if (_facingRight == false && dir.x > 0)
            {
                FlipCharacter();
                _leftOrRight = -1;
            }
            else if (_facingRight == true && dir.x < 0)
            {
                FlipCharacter();
                _leftOrRight = 1;
            }

            anim.SetFloat("move", Mathf.Abs(_rb.velocity.x));
        }
    }

    private IEnumerator Dash()
    {
        if (!isDashing) {
            canDash = false;
            _nextDash = Time.time + _dashCooldown;
            isDashing = true;

            float gravity = _rb.gravityScale;
            float drag = _rb.drag;
            _rb.gravityScale = 0;
            _rb.drag = _dashLinearDrag;

            _rb.velocity = new Vector2(_rb.velocity.x, 0f);
            _rb.AddForce(new Vector2(_dashDistance * (_facingRight ? 1 : -1), 0), ForceMode2D.Impulse);

            yield return new WaitForSeconds(_dashDuration);

            isDashing = false;
            _rb.gravityScale = gravity;
            _rb.drag = drag;
        }
    }

    private void WallSlide()
    {
        
        _rb.velocity = new Vector2(_rb.velocity.x, - _slideSpeed);
        FlipCharacter();
    }

    private void Walk(Vector2 dir)
    {
        if (!isDashing)
            _rb.velocity = new Vector2(dir.x * _speed, _rb.velocity.y);
    }
    
    private void Jump(Vector2 dir, bool isDoubleJump)
    {
        if (!isDashing) { 
            if(isDoubleJump == true)
            {
                _isDoubleJump= false;
            }

                _rb.velocity = new Vector2(_rb.velocity.x, 0);
                _rb.velocity += dir * _jumpVelocity;
        }
        
    }

    private void WallJump()
    {
        _rb.velocity = new Vector2(_wallJumpVelocityX * _leftOrRight, _wallJumpVelocityY);
    }
    void CancelWallJump()
    {
        _wallJump = false;
    }
    void FlipCharacter()
    {
        _facingRight = !_facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    
    public void EnableDash(int i)
    {
        PlayerPrefs.SetInt("DashEnabled", 1);
    }

    private void OnEnable()
    {
        controls.PControls.Enable();
    }

    private void OnDisable()
    {
        controls.PControls.Disable();
    }
}
