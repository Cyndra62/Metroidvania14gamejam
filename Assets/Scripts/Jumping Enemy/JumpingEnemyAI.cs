using System;
using UnityEngine;

namespace Jumping_Enemy
{
    public class JumpingEnemyAI : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        
        [SerializeField] private Transform checkOnGround, checkHittingWall;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float jumpForce, walkSpeed, maxDistance, lineOfSight, chaseSpeed;
        [SerializeField] private Rigidbody2D playerRigidbody;

        private bool _isOnGround;
        private bool _hittingWall;
        private bool _needsToJump;
        private bool _facingRight;
        private bool _needsToFlip;

        private float _xOrigin;
        private float _distanceFromOrigin;

        private Vector2 _distanceToPlayer;
        private Vector2 _currentPosition;

        private void Start()
        {
            _rigidbody = gameObject.GetComponent<Rigidbody2D>();
            _currentPosition = _rigidbody.position;
            _isOnGround = false;
            _hittingWall = false;
            _facingRight = true;
            _needsToFlip = false;
            _xOrigin = _currentPosition.x;
            _distanceFromOrigin = 0f;
            _distanceToPlayer = _currentPosition - playerRigidbody.position;
        }

        private void Update()
        {
            _currentPosition = _rigidbody.position;
            _distanceFromOrigin = _currentPosition.x - _xOrigin;
            _isOnGround = Physics2D.OverlapCircle(checkOnGround.position, 0.1f, groundLayer);
            _hittingWall = Physics2D.OverlapCircle(checkHittingWall.position, 0.1f, groundLayer);
            _distanceToPlayer = playerRigidbody.position - _currentPosition;
            _needsToJump = _distanceToPlayer.x < lineOfSight || _distanceToPlayer.y < lineOfSight;
            _needsToFlip = _distanceToPlayer.x > 0 && !_facingRight || _distanceToPlayer.x < 0 && _facingRight;
        }

        private void FixedUpdate()
        {
            if (_isOnGround)
            {
                if (_needsToJump)
                {
                    _rigidbody.AddForce(new Vector2(_distanceToPlayer.x * chaseSpeed, jumpForce), ForceMode2D.Impulse);
                }
                else
                {
                    _rigidbody.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, _rigidbody.velocity.y);
                }
            }
            if (_hittingWall || (Mathf.Abs(_distanceFromOrigin) > maxDistance && !_needsToJump) || _needsToFlip)
            {
                Flip();
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
