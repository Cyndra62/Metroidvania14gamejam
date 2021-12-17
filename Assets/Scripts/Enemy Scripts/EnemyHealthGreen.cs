using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthGreen : MonoBehaviour
{
    public GameObject enemy;
    public int currentHealth, maxHealth;
    private float invincibleCounter;
    private float colorRedCounter;
    private float colorWhiteCounter;
    public float invincibleTime;
    public float colorHurtTime;
    public SpriteRenderer theSR;
    //public GameObject deathEffect;
    public BoxCollider2D theCollider;
    public Collider2D impactCollider;
    private bool takeDamage;


    private void Start()
    {
        currentHealth = maxHealth;
        takeDamage = true;
    }

    private void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            if (colorRedCounter > 0)
            {
                colorRedCounter -= Time.deltaTime;
                if (colorRedCounter <= 0)
                {
                    theSR.color = new Color(1, 1, 1, .5f);
                    colorWhiteCounter = colorHurtTime;
                    theSR.color = new Color(1, 1, 1, .5f);
                }
            }

            if (colorWhiteCounter > 0)
            {
                colorWhiteCounter -= Time.deltaTime;
                if (colorWhiteCounter <= 0)
                {
                    theSR.color = new Color(1, 1, 1, .5f);
                    colorRedCounter = colorHurtTime;
                    theSR.color = new Color(1, 0, 0, .7f);
                }
            }

            if (invincibleCounter <= 0)
            {
                theSR.color = new Color(1, 1, 1, 1);
                theCollider.enabled = true;
                impactCollider.enabled = true;
                takeDamage = true;
            }
        }
    }

    public void TakeDamage()
    {

        if (invincibleCounter <= 0)
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                //GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
                //Destroy(effect, 2f);
            }
            else
            {
                invincibleCounter = invincibleTime;
                theCollider.enabled = false;
                impactCollider.enabled = false;
                theSR.color = new Color(1, 0, 0, .7f);
                colorRedCounter = colorHurtTime;

            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Green Halo"))
        {
            Debug.Log("Laser touch jump enemy");
            TakeDamage();

            if (takeDamage)
            {

                Destroy(other.gameObject);
                takeDamage = false;

                if (invincibleCounter <= 0)
                {

                    Destroy(other.gameObject);

                }
            }
        }
    }
}
