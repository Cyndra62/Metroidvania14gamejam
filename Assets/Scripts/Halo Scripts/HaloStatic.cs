using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloStatic : MonoBehaviour
{
    public int _zSpeed;
    public int _xSpeed;
    void Update()
    {
        this.transform.Rotate (_xSpeed*Time.deltaTime,0,_zSpeed*Time.deltaTime);
    }
}
