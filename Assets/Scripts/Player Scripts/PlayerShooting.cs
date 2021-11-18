using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header ("Player Info")]
    public GameObject _player;
    public Transform _shotPoint;
    public GameObject _halo;

    [Space]
    public float _launchForce;
    private GameObject _playerArm;
    private float _rotZ;

    [Space]
    [SerializeField] private GameObject newHalo;

    [Header ("Ammo Info")]
    [SerializeField] public int _ammoCount = 0;
    [SerializeField] private bool _canShoot;
    [SerializeField] public GameObject[] _ammoLineup;

    private Collider2D _playerCollider;
    public PlayerMovement _playerMovement;


    private void Start() 
    {
        _playerArm = _player.transform.GetChild(0).gameObject;
        _playerMovement = GetComponent<PlayerMovement>();
        _playerCollider = _player.GetComponent<Collider2D>();
        
    }
    private void FixedUpdate() 
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        diff.Normalize();

        _rotZ = Mathf.Atan2(diff.y,diff.x) * Mathf.Rad2Deg;

        _playerArm.transform.rotation = Quaternion.Euler(0f, 0f, _rotZ);

        if(_playerMovement._facingRight==true)
        {
            _playerArm.transform.localRotation = Quaternion.Euler(180, 0 , -_rotZ);
        }
        else if(_playerMovement._facingRight==false)
        {
            _playerArm.transform.localRotation = Quaternion.Euler(180, 180, -_rotZ);
        }

    }
    private void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        
        if(_ammoCount < 3)
        {
            _canShoot = true;
        }
        else
        {
            _canShoot = false;
        }
        if(_canShoot)
        {
            if(_ammoCount==0)
            {
                newHalo = Instantiate(_ammoLineup[_ammoCount]);
                _ammoCount++;
            }
            else if(_ammoCount==1)
            {
                newHalo = Instantiate(_ammoLineup[_ammoCount]);
                _ammoCount++;
            }
            else if(_ammoCount==2)
            {
                newHalo = Instantiate(_ammoLineup[_ammoCount]);
                _ammoCount++;
            }
        
            newHalo.transform.position = _shotPoint.position;
            newHalo.transform.rotation =  Quaternion.Euler(0,0, _rotZ);

            if(_playerMovement._facingRight==true)
            {
                newHalo.GetComponent<Rigidbody2D>().velocity = _shotPoint.right * _launchForce;
            }
            else
            {
                newHalo.GetComponent<Rigidbody2D>().velocity = (_shotPoint.right * _launchForce) *-1;
            }
            
            Collider2D newHaloCollider = newHalo.GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(newHaloCollider, _playerCollider);
            }
    }
}
