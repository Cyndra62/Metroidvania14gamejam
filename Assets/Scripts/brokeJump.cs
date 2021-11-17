using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brokeJump : MonoBehaviour
{
    [Header ("Components")]
    private Rigidbody2D _rb;

    [Header ("Layer Masks")]
    [SerializeField] private LayerMask _groundLayer;

    [Header ("Movement Variables")]
    [SerializeField] private float _movementAcceleration;
    [SerializeField] private float _maxMoveSpeed;
    [SerializeField] private float _linearDrag;
    private float _horizontalDirection;
    private bool _changingDirection => (_rb.velocity.x > 0f && _horizontalDirection < 0f) || (_rb.velocity.x < 0f && _horizontalDirection > 0f);

    [Header ("Jump Variables")]
    [SerializeField] private float _jumpForce;

    [Header ("Ground Vollision Variables")]
    [SerializeField] private float _groundRaycastLength;
    private bool _onGround;
    private bool _canJump => (Input.GetButtonDown("Jump") && _onGround);

    private void Start() 
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }

    
    private void Update() 
    {
        
        _horizontalDirection = GetInput().x;
    
    }

    private void FixedUpdate() 
    {
        CheckCollision();
        MoveCharacter();
        ApplyLinearDrag();
        if(_canJump) Jump();
        
    }

    private static Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void MoveCharacter()
    {
        _rb.AddForce(new Vector2(_horizontalDirection, 0f)* _movementAcceleration);

        if(Mathf.Abs(_rb.velocity.x) > _maxMoveSpeed)
        {
            _rb.velocity = new Vector2(Mathf.Sign(_rb.velocity.x) * _maxMoveSpeed, _rb.velocity.y);
        }
    }

    private void ApplyLinearDrag()
    {
        if (Mathf.Abs(_horizontalDirection) < 0.4f || _changingDirection)
        {
            _rb.drag = _linearDrag;
        }
        else
        {
            _rb.drag = 0f;
        }
    }

    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, 0f);
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void CheckCollision()
    {
        _onGround = Physics2D.Raycast(this.transform.position * _groundRaycastLength, Vector2.down, _groundRaycastLength, _groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _groundRaycastLength);
    }
}

