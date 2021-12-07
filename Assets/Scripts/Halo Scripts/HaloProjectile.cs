using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloProjectile : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    
    [SerializeField] private bool _wallCheck;
    public PlayerShooting _playerShooting;
    public string _haloColor;

    public float bulletTimeReset, bulletSpeedTime;
    public float counterBulletReset,counterSpeedBullet;
    public bool shooted, close;
    public float moveSpeed;
    public Rigidbody2D theRB;
    [SerializeField] private float sphereRadius;

    private void Start() 
    {   
        _playerShooting = FindObjectOfType<PlayerShooting>();
        shooted = false;
        close = false;
        //Vector3 bullet = Vector3.MoveTowards(transform.position, FindObjectOfType<PlayerMovement>().transform.position, moveSpeed * Time.deltaTime);
        moveSpeed = 0;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, FindObjectOfType<PlayerMovement>().transform.position, moveSpeed * Time.deltaTime);
        if (_playerShooting._ammoCount < 2 && !shooted)
        {
            shooted = true;
            close = true;
            //moveSpeed = 0;
            counterBulletReset = bulletTimeReset;
        }

        if (counterBulletReset > 0)
        {
            counterBulletReset -= Time.deltaTime;
            if (counterBulletReset <= 0)
            {
                //transform.position = Vector3.MoveTowards(transform.position,FindObjectOfType<PlayerMovement>().transform.position, moveSpeed * Time.deltaTime);
                //shooted = false;
                if(_playerShooting._ammoCount == 2 && shooted)
                {
                    shooted = false;
                    close = false;
                }

                /*if (close)
                {
                    moveSpeed = 5;
                }
                else
                {
                    moveSpeed = 0;
                }*/
                moveSpeed = 5;
                theRB.gravityScale = 0;
                GetComponent<BoxCollider2D>().enabled = false;
             
                
                
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, FindObjectOfType<PlayerMovement>().transform.position) < 1f)
            {

                //moveSpeed = 5;
                
                GetComponent<BoxCollider2D>().enabled = true;
                theRB.gravityScale = 1;
                counterSpeedBullet = bulletSpeedTime;
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

    private IEnumerator MoveResetCo()
    {
        yield return new WaitForSeconds(.2f);
        
        moveSpeed = 0;
        yield return new WaitForSeconds(.2f);
        counterBulletReset = bulletTimeReset;
    }
}
