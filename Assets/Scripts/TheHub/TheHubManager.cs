using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheHubManager : MonoBehaviour
{
    public static TheHubManager instance;
    public GameObject fadeScreen, mainMenu, optionsMenu, pauseMenu, uiHealth, uiHalosVisual;
    public float inLevelTime;
    private float counterInLevel;
    public Transform playerStartPosition;
    public bool isSaved;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        IsSavedScene.instance.canShoot = false;
        mainMenu.SetActive(false);
        uiHealth.SetActive(true);
        uiHalosVisual.SetActive(true);
        //FindObjectOfType<PlayerShooting>().shooting = false;
        //FindObjectOfType<PlayerShooting>()._canShoot = true;
        FindObjectOfType<Player>().transform.position = playerStartPosition.transform.position;

        isSaved = false;
        counterInLevel = inLevelTime;
        fadeScreen.SetActive(true);
        //IsContinue();
    }

    private void Update()
    {
        

        if (counterInLevel > 0)
        {
           

            counterInLevel -= Time.deltaTime;
            if(counterInLevel <= 0)
            {
                //IsContinue();
                /*if (IsSavedScene.instance.isContinue == true)
                {
                    GameManager.instance.LoadData();
                    IsSavedScene.instance.isContinue = false;
                }*/
                /*if (IsSavedScene.instance.canShoot)
                {
                    FindObjectOfType<PlayerShooting>().shooting = false;
                    FindObjectOfType<PlayerShooting>()._canShoot = true;
                }

                if (IsSavedScene.instance.isContinue == true)
                {
                    FindObjectOfType<PlayerShooting>().shooting = false;
                    FindObjectOfType<PlayerShooting>()._canShoot = true;
                    GameManager.instance.LoadData();
                    IsSavedScene.instance.isContinue = false;
                    //IsSavedScene.instance.isSaved = true;

                }*/
                UiFade.instance.FadeFromBlack();
            }
        }
    }

    public void IsContinue()
    {
        if (isSaved)
        {
            GameManager.instance.LoadData();

        }
        else
        {
           // FindObjectOfType<PlayerMovement>().transform.position = playerStartPosition.transform.position;
        }
    }
}
