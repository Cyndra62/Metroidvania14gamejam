using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    public int currentPoint;
    public Transform platform;
    public float waitTime;
    private float counterTime;
    [SerializeField] public bool isMoving = false;

    private void Start()
    {
        counterTime = waitTime;
    }
    void Update()
    {
        
        platform.position = Vector3.MoveTowards(platform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(platform.position, points[currentPoint].position) < .1f && !isMoving)
        {
            //StartCoroutine(WaitToMoveCo());
            counterTime = waitTime;
            isMoving = true;
            
        }
        if(counterTime > 0)
        {
            counterTime -= Time.deltaTime;
            if(counterTime <= 0)
            {
                isMoving = false;
                currentPoint++;
                if (currentPoint >= points.Length)
                {
                    currentPoint = 0;
                }
            }
        }
    }
   /* public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            transform.parent = other.transform;

        }
    }
    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
    }*/
}

