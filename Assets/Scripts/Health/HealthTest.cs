using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTest : MonoBehaviour
{
    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            health.Damage(10);
        }

        if (Input.GetMouseButtonDown(1))
            health.Heal(2);
    }
}
