using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaToEnter : MonoBehaviour
{
    public string transitionName;

    void Start()
    {
        if (transitionName == PlayerMovement.instance.areaTransitionName)
        {
            PlayerMovement.instance.transform.position = transform.position;
        }
    }
}
