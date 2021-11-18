using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerCollision _playerCollision;

    private Rigidbody2D _rb;

    [Header ("Movement Variables")]
    [SerializeField] private float _speed;
    [SerializeField] private float _slideSpeed;
    [SerializeField] private float _jumpVelocity;
    [SerializeField] private float _wallJumpVelocityX;
    [SerializeField] private float _wallJumpVelocityY;
    

    [Header ("Booleans")]
    [SerializeField] public bool _isDoubleJump = true;
    [SerializeField] private bool _pushingWall = false;
    [SerializeField] public bool _facingRight = true;
    [SerializeField] public bool _wallJump = false;
    [SerializeField] public int _leftOrRight;
    private void Start() 
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerCollision =GetComponent<PlayerCollision>();
    }

    private void Update() 
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);
        Walk(dir);

        if(_playerCollision._onWall && !_playerCollision._onGround && _pushingWall == true)
        {
            WallSlide();
        }
        if(_playerCollision._onGround)
        {
            _isDoubleJump= true;
            _wallJump = false;
        }
        
        if((_rb.velocity.x > 0 && _playerCollision._onRightWall) || (_rb.velocity.x < 0 && _playerCollision._onLeftWall))
        {
            _pushingWall = true;
            
        }
        else
        {
            _pushingWall = false;
        }

        if(_pushingWall == true && !_playerCollision._onGround && Input.GetButtonDown("Jump"))
        {
            _wallJump = true;
            Invoke ("CancelWallJump",0.2f);
        }

        if(_wallJump)
        {
            WallJump();
        }

        if (Input.GetButtonDown("Jump"))
        {
            if(_playerCollision._onGround)
            {
                Jump(Vector2.up, false);
            }
            else if(!_playerCollision._onGround && _isDoubleJump==true && _pushingWall==false)
            {
                Jump(Vector2.up, true);
            }
        }

        
        if(_facingRight == false && x > 0)
        {
            FlipCharacter();
            _leftOrRight = -1;
        }
        else if( _facingRight == true && x < 0)
        {
            FlipCharacter();
            _leftOrRight = 1;
        }

        
    }

    private static Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void WallSlide()
    {
        
        _rb.velocity = new Vector2(_rb.velocity.x, - _slideSpeed);
        FlipCharacter();
    }

    private void Walk(Vector2 dir)
    {
       _rb.velocity = new Vector2(dir.x * _speed, _rb.velocity.y);
    }
    
    private void Jump(Vector2 dir, bool isDoubleJump)
    {
        if(isDoubleJump == true)
        {
            _isDoubleJump= false;
        }

            _rb.velocity = new Vector2(_rb.velocity.x, 0);
            _rb.velocity += dir * _jumpVelocity;
        
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
    
}
