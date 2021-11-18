using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloProjectile : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    
    [SerializeField] private bool _wallCheck;
    public PlayerShooting _playerShooting;


    private void Start() 
    {   
        _playerShooting = FindObjectOfType<PlayerShooting>();
        
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
            _playerShooting.Reload(gameObject);
            gameObject.SetActive(false);
            _wallCheck= false;
        }
        
    }
}
