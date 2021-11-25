using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheHubManager : MonoBehaviour
{
    public GameObject fadeScreen;
    public float inLevelTime;
    private float counterInLevel;

    private void Start()
    {
        counterInLevel = inLevelTime;
        fadeScreen.SetActive(true);
    }

    private void Update()
    {
        if(counterInLevel > 0)
        {
            counterInLevel -= Time.deltaTime;
            if(counterInLevel <= 0)
            {
                UiFade.instance.FadeFromBlack();
            }
        }
    }

    
}
