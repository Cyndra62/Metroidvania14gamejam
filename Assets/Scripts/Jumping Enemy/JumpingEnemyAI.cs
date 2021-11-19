using System;
using UnityEngine;
using UnityEngineInternal;

namespace Jumping_Enemy
{
    public class JumpingEnemyAI : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        
        [SerializeField] private Transform checkOnGround, checkHittingWall;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float jumpForce, walkSpeed, maxDistance, lineOfSight;
        [SerializeField] private Rigidbody2D playerRigidbody;

        private bool _isOnGround;
        private bool _hittingWall;
        private bool _needsToJump;
        private bool _facingRight;
        private bool _needsToFaceEnemy;

        private float _xOrigin;
        private float _distanceFromOrigin;
        private float _timeToNextJump;

        private Vector2 _distanceToPlayer;
        private Vector2 _currentPosition;

        private void Start()
        {
            _rigidbody = gameObject.GetComponent<Rigidbody2D>();
            _currentPosition = _rigidbody.position;
            _isOnGround = false;
            _hittingWall = false;
            _facingRight = true;
            _xOrigin = _currentPosition.x;
            _distanceFromOrigin = 0f;
            _timeToNextJump = 1f;
            _distanceToPlayer = _currentPosition - playerRigidbody.position;
        }

        private void Update()
        {
            _currentPosition = _rigidbody.position;
            _distanceFromOrigin = _currentPosition.x - _xOrigin;
            _isOnGround = Physics2D.OverlapCircle(checkOnGround.position, 0.1f, groundLayer);
            _hittingWall = Physics2D.OverlapCircle(checkHittingWall.position, 0.1f, groundLayer);
            _distanceToPlayer = playerRigidbody.position - _currentPosition;
            if (!_needsToJump && Mathf.Abs(_distanceToPlayer.x) < lineOfSight)
            {
                _needsToJump = true;
            }
            _needsToFaceEnemy = (_distanceToPlayer.x > 0 && !_facingRight || _distanceToPlayer.x < 0 && _facingRight) && _needsToJump;
        }

        private void FixedUpdate()
        {
            if (_hittingWall || (Mathf.Abs(_distanceFromOrigin) > maxDistance && !_needsToJump) || _needsToFaceEnemy)
            {
                Flip();
            }
            if (_isOnGround)
            {
                if (_needsToJump)
                {
                    if (_timeToNextJump < 0)
                    {
                        if (_facingRight)
                        {
                            _rigidbody.AddForce(new Vector2(1, 1) * jumpForce, ForceMode2D.Impulse);
                        }
                        else
                        {
                            _rigidbody.AddForce(new Vector2(-1, 1) * jumpForce, ForceMode2D.Impulse);
                        }
                        _timeToNextJump = 1f;
                    }
                    else
                    {
                        _timeToNextJump -= Time.fixedDeltaTime;
                    }
                }
                else
                {
                    _rigidbody.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, _rigidbody.velocity.y);
                }
            }
        }

        private void Flip()
        {
            walkSpeed *= -1;
            transform.localScale *= new Vector2(-1, 1);
            _facingRight = !_facingRight;
        }
    }
}
