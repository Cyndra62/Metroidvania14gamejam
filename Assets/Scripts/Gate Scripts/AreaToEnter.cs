using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaToEnter : MonoBehaviour
{
    public string transitionName;

    void Start()
    {
        if (transitionName == Player.instance.areaTransitionName)
        {
            Player.instance.transform.position = transform.position;
        }
    }
}
