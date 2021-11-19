using System;
using UnityEngine;

namespace Jumping_Enemy
{
    public class JumpingEnemyAI : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        
        [SerializeField] private Transform checkOnGround, checkHittingWall;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float jumpForce, walkSpeed;

        private bool _isOnGround;
        private bool _hittingWall;

        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            _rigidbody = gameObject.GetComponent<Rigidbody2D>();
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _isOnGround = false;
            _hittingWall = false;
        }

        private void Update()
        {
            _isOnGround = Physics2D.OverlapCircle(checkOnGround.position, 0.1f, groundLayer);
            _hittingWall = Physics2D.OverlapCircle(checkHittingWall.position, 0.1f, groundLayer);
        }

        private void FixedUpdate()
        {
            if (_isOnGround)
            {
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            if (_hittingWall)
            {
                Flip();
            }

            _rigidbody.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, _rigidbody.velocity.y);
        }

        private void Flip()
        {
            walkSpeed *= -1;
            transform.localScale *= new Vector2(-1, 1);
        }
    }
}
