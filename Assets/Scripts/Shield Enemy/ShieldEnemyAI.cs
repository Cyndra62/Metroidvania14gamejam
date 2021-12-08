using System;
using UnityEngine;

public class ShieldEnemyAI : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private GameObject exclamationMark;
    [SerializeField] private GameObject shield;

    [SerializeField] private float visionArea;
    [SerializeField] private float shieldCooldown;
    [SerializeField] private float activeShieldDuration;
    [SerializeField] private float health;

    private byte _currentState; //0 - inactive, 1 - active, no shield, 2 - active, shield up

    private float _currentShieldCooldown;
    private float _currentActiveShieldDuration;
    
    private Vector2 _distanceToPlayer;

    private bool _facingRight;

    private void Start()
    {
        //Getting the needed shield enemy components
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        exclamationMark.SetActive(false);
        shield.SetActive(false);
        
        //Initialising the shield enemy attributes
        _currentState = 0;
        _currentShieldCooldown = shieldCooldown;
        _facingRight = false;
    }

    private void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
        
        //Every frame, update the distance to the player
        _distanceToPlayer = playerRigidbody.position - _rigidbody.position;

        //If the player is inside the enemy's vision, change the enemy's state to active,
        //otherwise change it to inactive
        if (Mathf.Abs(_distanceToPlayer.x) < visionArea && _distanceToPlayer.y < visionArea)
        {
            if (_currentState == 0)
            {
                _currentState = 1;

                exclamationMark.SetActive(true);
            }
        }
        else
        {
            _currentState = 0;
            
            //Reset the shield cooldown
            _currentShieldCooldown = shieldCooldown;
            _currentActiveShieldDuration = activeShieldDuration;

            exclamationMark.SetActive(false);
            shield.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        CheckState();
        CheckNeedToFlip();
    }

    private void CheckState()
    {
        switch (_currentState)
        {
            case 1:
                _currentShieldCooldown -= Time.fixedDeltaTime;
                if (_currentShieldCooldown <= 0)
                {
                    _currentState = 2;
                    _currentShieldCooldown = shieldCooldown;
                    
                    exclamationMark.SetActive(false);
                    shield.SetActive(true);
                }
                break;
            case 2:
                _currentActiveShieldDuration -= Time.fixedDeltaTime;
                if (_currentActiveShieldDuration <= 0)
                {
                    _currentState = 1;
                    _currentActiveShieldDuration = activeShieldDuration;

                    shield.SetActive(false);
                }
                break;
        }
    }

    private void CheckNeedToFlip()
    {
        if (_facingRight && _distanceToPlayer.x < 0 || !_facingRight && _distanceToPlayer.x > 0)
        {
            Flip();
            _facingRight = !_facingRight;
        }
    }

    private void Flip()
    {
        transform.localScale *= new Vector2(-1, 1);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            health -= 1;
        }
    }
}
