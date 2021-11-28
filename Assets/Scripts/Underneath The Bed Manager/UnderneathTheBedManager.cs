using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderneathTheBedManager : MonoBehaviour
{
    public static UnderneathTheBedManager instance;
    public GameObject fadeScreen;
    public float inLevelTime;
    private float counterInLevel;
    public Transform playerStartPosition;
    public GameObject thePlayer;

    private void Start()
    {
        thePlayer.transform.position = playerStartPosition.transform.position;
        counterInLevel = inLevelTime;
        fadeScreen.SetActive(true);
    }

    private void Update()
    {
        if (counterInLevel > 0)
        {
            counterInLevel -= Time.deltaTime;
            if (counterInLevel <= 0)
            {
                UiFade.instance.FadeFromBlack();
            }
        }
    }
}
