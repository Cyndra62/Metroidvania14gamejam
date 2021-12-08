using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloProjectile : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    
    [SerializeField] private bool _wallCheck;
    public PlayerShooting _playerShooting;
    public string _haloColor;

    public float bulletTimeReset, bulletSpeedTime, gravityTime;
    public float counterBulletReset,counterSpeedBullet, counterGravity;
    public bool shooted, close;
    public float moveSpeed;
    public Rigidbody2D theRB;
    [SerializeField] private float sphereRadius;

    private void Start() 
    {   
        _playerShooting = FindObjectOfType<PlayerShooting>();
        shooted = false;
        close = false;
        moveSpeed = 0;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, FindObjectOfType<PlayerMovement>().transform.position, moveSpeed * Time.deltaTime);
        if (FindObjectOfType<PlayerShooting>()._ammoCount < 2 && !shooted)
        {
            shooted = true;
            close = true;
            IsSavedScene.instance.canTravel = false;
            counterBulletReset = bulletTimeReset;
        }

       // if(FindObjectOfType<PlayerShooting>()._ammoCount == 2 )
        //{
         //   FindObjectOfType<IsSavedScene>().canTravel = true;
        //}

        if (counterBulletReset > 0)
        {
            counterBulletReset -= Time.deltaTime;
            if (counterBulletReset <= 0)
            {
                if(_playerShooting._ammoCount == 2 && shooted)
                {
                    shooted = false;
                    close = false;
                    //IsSavedScene.instance.canTravel = true;
                }
                moveSpeed = 5;
                theRB.gravityScale = 0;
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, FindObjectOfType<PlayerMovement>().transform.position) < 1f)
            {
                GetComponent<BoxCollider2D>().enabled = true;
                theRB.gravityScale = 1;
                counterSpeedBullet = bulletSpeedTime;
                counterGravity = gravityTime;
                //StartCoroutine(MoveResetCo());
            }
        }

        if(counterSpeedBullet > 0)
        {
            counterSpeedBullet -= Time.deltaTime;
            if(counterSpeedBullet <= 0)
            {
                moveSpeed = 0;
                counterBulletReset = bulletTimeReset;
            }
        }
        if(transform.position.y <= -1)
        {
            transform.position = new Vector2(transform.position.x, -0.5f);
            theRB.velocity = new Vector2(0, 0);
        }

        if(counterGravity > 0)
        {
            counterGravity -= Time.deltaTime;
            if(counterGravity <= 0)
            {
                theRB.gravityScale = 1;
            }
        }
        else
        {
            if(Vector3.Distance(transform.position, FindObjectOfType<PlayerMovement>().transform.position) < 1f)
            {
                //GetComponent<BoxCollider2D>().enabled = true;
                theRB.gravityScale = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Platform"))
        {
            _wallCheck = true;
        }
        if(_wallCheck== true)
        {
            _playerShooting.Pickup(gameObject);
        }
        if(_wallCheck== true && other.gameObject.CompareTag("Player"))
        {
            _playerShooting.Reload(gameObject, _haloColor);
            gameObject.SetActive(false);
            _wallCheck= false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }

    
}
