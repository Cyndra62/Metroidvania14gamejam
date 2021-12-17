using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheAscensionManager : MonoBehaviour
{
    public GameObject fadeScreen;
    public float inLevelTime;
    private float counterInLevel;
    public Animator anim;
    public float portalFadingTime;
    public GameObject uiHealthVisual, uiHalosVisual;

    void Start()
    {
        uiHalosVisual.SetActive(true);
        uiHealthVisual.SetActive(true);
        counterInLevel = inLevelTime;
        fadeScreen.SetActive(true);
        //FindObjectOfType<PlayerMovement>().PlayerGravityZero();

    }
    
    void Update()
    {
        if(counterInLevel > 0)
        {
            counterInLevel -= Time.deltaTime;
            if(counterInLevel <= 0)
            {
                UiFade.instance.FadeFromBlack();
                anim.SetBool("open", true);
                StartCoroutine(FadingPortalCo());
                
            }
        }
    }

    private IEnumerator FadingPortalCo()
    {
        yield return new WaitForSeconds(portalFadingTime);
        anim.SetBool("open", false);
    }
}
