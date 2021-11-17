using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerCollision _playerCollision;

    private Rigidbody2D _rb;

    public bool _isDoubleJump = true;

    [Header ("Movement Variables")]
    [SerializeField] private float _speed;
    [SerializeField] private float _slideSpeed;
    [SerializeField] private float _jumpVelocity;


    

    [SerializeField] private bool _pushingWall = false;

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
        }
        
        if((_rb.velocity.x > 0 && _playerCollision._onRightWall) || (_rb.velocity.x < 0 && _playerCollision._onLeftWall))
        {
            _pushingWall = true;
        }
        else
        {
            _pushingWall = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if(_playerCollision._onGround)
            {
                Jump(Vector2.up, false, false);
            }
            else if(!_playerCollision._onGround && _isDoubleJump==true && _pushingWall==false)
            {
                Jump(Vector2.up, false, true);
            }
        }

        
    }

    private static Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void WallSlide()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, - _slideSpeed);
    }

    private void Walk(Vector2 dir)
    {
       _rb.velocity = new Vector2(dir.x * _speed, _rb.velocity.y);
    }
    
    private void Jump(Vector2 dir, bool isWall, bool isDoubleJump)
    {
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        _rb.velocity += dir * _jumpVelocity;
        
        if(isDoubleJump == true)
        {
            _isDoubleJump= false;
        }
    }
    
    
}
