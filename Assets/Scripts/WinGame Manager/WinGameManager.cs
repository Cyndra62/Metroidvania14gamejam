using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameManager : MonoBehaviour
{
    public GameObject fadeScreen;
    public float timeToFade;
    private float counterFade;

    void Start()
    {
        fadeScreen.SetActive(true);
        counterFade = timeToFade;
    }

    
    void Update()
    {
        if(counterFade > 0)
        {
            counterFade -= Time.deltaTime;
            if(counterFade <= 0)
            {
                UiFade.instance.FadeFromBlack();
            }
        }
    }
}
