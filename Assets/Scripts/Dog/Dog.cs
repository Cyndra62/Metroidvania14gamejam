using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    public int currentPoint;
    public AudioSource wings;
    public AudioClip wings1;

    public Transform theSR;

    public float distanceToAttack, chaseSpeed;

    private Vector3 attackTarget;

    //private bool hasAttacked;
    public float waitAfterAttack, soundTimeMin, soundTimeMax, delaymin, delaymax;
    private float attackCounter, counterSound, counterDelay;
    
    void Start()
    {
        counterDelay = Random.Range(delaymin, delaymax);
        wings.PlayOneShot(wings1);
        for (int i = 0; i < points.Length; i++)
        {
            points[i].parent = null;
        }

    }

    void Update()
    {
        //wings.PlayOneShot(wings1);
        //AudioManager.instance.PlaySFX(62);
        if(counterDelay > 0)
        {
            counterDelay -= Time.deltaTime;
            if(counterDelay <= 0)
            {
                wings.PlayOneShot(wings1);
                counterSound = Random.Range(soundTimeMin, soundTimeMax);

            }
        }
        if(counterSound > 0)
        {
            counterSound -= Time.deltaTime;
            if(counterSound <= 0)
            {
                //wings.PlayOneShot(wings1);
                counterDelay = Random.Range(delaymin, delaymax);
            }
        }
        if (attackCounter > 0)
        {
            attackCounter -= Time.deltaTime;
        }
        else
        {
            if (Vector3.Distance(transform.position, Player.instance.transform.position) > distanceToAttack)
            {

                attackTarget = Vector3.zero;

                transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, points[currentPoint].position) < .1f)
                {
                    currentPoint++;

                    if (currentPoint >= points.Length)
                    {
                        currentPoint = 0;
                    }
                }

                if (transform.position.x < points[currentPoint].position.x)
                {
                    theSR.transform.localScale = new Vector2(-1,1);
                }
                else if (transform.position.x > points[currentPoint].position.x)
                {
                    theSR.transform.localScale = new Vector2(1, 1);
                }
            }
            else
            {
                if (attackTarget == Vector3.zero)
                {
                    attackTarget = Player.instance.transform.position;
                }

                transform.position = Vector3.MoveTowards(transform.position, attackTarget, chaseSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, attackTarget) <= .1f)
                {
                    // hasAttacked = true;
                    attackCounter = waitAfterAttack;
                    attackTarget = Vector3.zero;
                }
            }
        }
    }
}
