using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetManager : MonoBehaviour
{
    public static ClosetManager instance;
    public GameObject fadeScreen;
    public float inLevelTime;
    private float counterInLevel;
    public Transform playerSpawnPoint;
    public bool isSaved;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        IsSavedScene.instance.canShoot = false;
        if (IsSavedScene.instance.isContinue == true)
        {
            GameManager.instance.LoadData();
        }
        /*else
        {
            FindObjectOfType<PlayerMovement>().transform.position = playerSpawnPoint.transform.position;
        }*/
        //PauseMenu.instance.isPause = true;
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
                if (IsSavedScene.instance.isContinue == true && isSaved == true)
                {
                    GameManager.instance.LoadData();
                    IsSavedScene.instance.isContinue = false;
                    isSaved = false;
                }
                //FindObjectOfType<PlayerMovement>().transform.position = playerSpawnPoint.transform.position;

                UiFade.instance.FadeFromBlack();
            }
        }
    }
}
