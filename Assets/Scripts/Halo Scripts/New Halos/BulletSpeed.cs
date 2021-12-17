using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    public static BulletSpeed instance;
    public float speed;
    public float lifeTime;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        transform.position += new Vector3(-speed * transform.lossyScale.x * Time.deltaTime, 0f, 0f);
        Destroy(gameObject, lifeTime);


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
