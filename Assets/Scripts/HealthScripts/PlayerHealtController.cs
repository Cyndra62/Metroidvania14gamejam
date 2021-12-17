using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealtController : MonoBehaviour
{
    public static PlayerHealtController instance;
    public int currentHealt;
    public int maxHealt;

    public float invincibleLenght;
    private float invicibleCountDown;
    private SpriteRenderer theSR;
    public GameObject deathEffect;
    public float rechargeLifeTime;
    private float counterLife;
    bool lifefull;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        lifefull = true;
        counterLife = rechargeLifeTime;
        currentHealt = maxHealt;
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invicibleCountDown > 0)
        {
            invicibleCountDown -= Time.deltaTime;
            if (invicibleCountDown <= 0)
            {
                //theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
                theSR.color = new Color(1f, 1f, 1f, 1f);

            }
        }
        if(currentHealt < maxHealt)
        {
            lifefull = false;
            
        }
        

        
        if(counterLife > 0 && !lifefull)
        {
            counterLife -= Time.deltaTime;
            if(counterLife <= 0)
            {
                counterLife = rechargeLifeTime;
                currentHealt++;
                UiController.instance.UpdateHealthDisplay();
                if(currentHealt == maxHealt)
                {
                    
                    lifefull = true;
                    UiController.instance.UpdateHealthDisplay();
                }
                else if(currentHealt > maxHealt)
                {
                    currentHealt = maxHealt;
                    UiController.instance.UpdateHealthDisplay();
                    lifefull = true;
                }
                
            }
            

        }

    }

    public void DealDamage()
    {
        if (invicibleCountDown <= 0)
        {
            //currentHealt = currentHealt - 1;
            //currentHealt -= 1;
            currentHealt--;

            if (currentHealt <= 0)
            {
                currentHealt = 0;
                //gameObject.SetActive(false);
                //Instantiate(deathEffect, transform.position, transform.rotation);
               // AudioManager.instance.StopMusic();
                //AudioManager.instance.PlaySFX(12);
                GameManager.instance.RespawnPlayer();
            }
            else
            {
                invicibleCountDown = invincibleLenght;
                theSR.color = new Color(theSR.color.r, theSR.color.b, theSR.color.g, .5f);
                Player.instance.KnockBack();
               // AudioManager.instance.PlaySFX(13);
            }

            UiController.instance.UpdateHealthDisplay();
        }
    }
    /*public void HealPlayer()
    {
        //currentHealt = maxHealt;  ==if we want full life restore.
        currentHealt++;
        if (currentHealt > maxHealt)
        {
            currentHealt = maxHealt;
        }
        UiController.instance.UpdateHealthDisplay();
    }*/

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
