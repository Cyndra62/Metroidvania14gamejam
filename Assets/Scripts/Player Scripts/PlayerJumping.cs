using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    public float _fallMultiplier = 2.5f;
    public float _lowJumpMultiplier = 2f;
    private PlayerControls controls;

    Rigidbody2D _rb;

    void Awake() 
    {
        _rb = GetComponent<Rigidbody2D>();
        controls = new PlayerControls();
        controls.PControls.Jump.performed += ctx =>
        {
            if (_rb.velocity.y > 0)
            {
                _rb.velocity += Vector2.up * Physics2D.gravity.y * (_lowJumpMultiplier - 1) * Time.deltaTime;
            }
        };
    }

    void Update() 
    {
        if(_rb.velocity.y < 0)
        {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
