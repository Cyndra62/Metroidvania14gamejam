using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public Transform bar;

    public void UpdateBar(float currentHealth, float maxHealth)
    {
        bar.localScale = new Vector3(currentHealth / maxHealth, 1, 1);
    }
}
