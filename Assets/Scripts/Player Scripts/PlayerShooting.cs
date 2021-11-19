using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header ("Player Info")]
    public GameObject _player;
    public Transform _shotPoint;
    public GameObject _halo;
    public GameObject _shootableHalo;
    public GameObject _ammoBelt;

    [Space]
    public float _launchForce;
    private GameObject _playerArm;
    private float _rotZ;

    [Space]
    [SerializeField] private GameObject newHalo;

    [Header ("Ammo Info")]
    [SerializeField] public int _ammoCount;
    [SerializeField] private bool _canShoot;
    [SerializeField] public List<GameObject> _ammoLineup = new List<GameObject>();

    private Collider2D _playerCollider;
    public PlayerMovement _playerMovement;
    private HaloProjectile _haloProjectile;


    private void Start() 
    {
        _playerArm = _player.transform.GetChild(0).gameObject;
        _playerMovement = GetComponent<PlayerMovement>();
        _playerCollider = _player.GetComponent<Collider2D>();
        _haloProjectile = GetComponent<HaloProjectile>();

        foreach(Transform halo in _shootableHalo.transform)
        {
            _ammoLineup.Add(halo.gameObject);
        }
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
        string haloName;
        if(_ammoCount >=0)
        {
            _canShoot = true;
        }
        else
        {
            _canShoot = false;
        }
        if(_canShoot)
        {
            if(_ammoCount==2)
            {
                newHalo =_ammoLineup[_ammoCount].gameObject;
            }
            else if(_ammoCount==1)
            {
                newHalo =_ammoLineup[_ammoCount].gameObject;
            }
            else if(_ammoCount==0)
            {
                newHalo = _ammoLineup[_ammoCount].gameObject;
            }
            
            haloName = newHalo.GetComponent<HaloProjectile>()._haloColor;

            foreach(Transform child in _ammoBelt.transform)
            {
                if(child.gameObject.tag == haloName)
                {
                    child.gameObject.SetActive(false);
                }
            }

            Physics2D.IgnoreCollision(newHalo.GetComponent<Collider2D>(), _playerCollider);
            newHalo.SetActive(true);
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
            _ammoLineup.RemoveAt(_ammoCount);
            _ammoCount--;
            }
    }

    public void Reload(GameObject halo, string haloColor)
    {
        _ammoLineup.Add(halo);
        _ammoCount++;
        
        foreach(Transform child in _ammoBelt.transform)
        {
            if(child.gameObject.tag == haloColor)
            {
                child.gameObject.SetActive(true);
            }
        }
    }

    public void Pickup(GameObject halo)
    {
        Physics2D.IgnoreCollision(halo.GetComponent<Collider2D>(), _playerCollider, false);
    }
}
