using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            FindObjectOfType<PlayerHealtController>().DealDamage();
           // PlayerHealtController.instance.DealDamage();
        }
    }
}
