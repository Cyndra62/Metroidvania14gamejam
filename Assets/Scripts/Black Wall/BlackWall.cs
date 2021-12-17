using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWall : MonoBehaviour
{
    public Transform theBlackWall;
    public Transform thEnd;
    public float movingSpeed;
    public float startTime;
    private float counterStart;
    private bool isMoving;
    void Start()
    {
        counterStart = startTime;
        isMoving = false;
    }
    
    void Update()
    {
        if(counterStart > 0)
        {
            counterStart -= Time.deltaTime;
            if(counterStart <= 0)
            {
                isMoving = true;
            }
        }
        if(isMoving)
        {
            theBlackWall.position = Vector3.MoveTowards(transform.position, thEnd.position, movingSpeed * Time.deltaTime);
        }
    }
}
