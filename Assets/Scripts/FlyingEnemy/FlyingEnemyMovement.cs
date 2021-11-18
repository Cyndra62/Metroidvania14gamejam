using System;
using UnityEngine;

namespace FlyingEnemy
{
    public class FlyingEnemyMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _spriteRenderer;

        private bool _isFollowingPlayer;
        private bool _facingRight;

        private Vector2 _directionToPlayer;

        public Rigidbody2D playerRigidbody;

        public float lineOfSight;
        public float flyingSpeed;

        public int health;

        private void Start()
        {
            _rigidbody = gameObject.GetComponent<Rigidbody2D>();
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _isFollowingPlayer = false;
            _facingRight = true;
            _directionToPlayer = playerRigidbody.position - _rigidbody.position;
        }

        private void Update()
        {
            if (health == 0)
            {
                Destroy(gameObject);
            }
            _directionToPlayer = playerRigidbody.position - _rigidbody.position;
            if (Mathf.Abs(_directionToPlayer.x) < lineOfSight || Mathf.Abs(_directionToPlayer.y) < lineOfSight)
            {
                _isFollowingPlayer = true;
            }
        }

        private void FixedUpdate()
        {
            if (_isFollowingPlayer)
            {
                if (_directionToPlayer.x > 0 && !_facingRight || _directionToPlayer.x < 0 && _facingRight)
                {
                    Flip();
                }
                _rigidbody.MovePosition(_rigidbody.position + _directionToPlayer.normalized * flyingSpeed * Time.fixedDeltaTime);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                health -= 1;
            }
        }

        private void Flip()
        {
            _facingRight = !_facingRight;
            transform.localScale *= new Vector2(-1, 1);
        }
    }
}
