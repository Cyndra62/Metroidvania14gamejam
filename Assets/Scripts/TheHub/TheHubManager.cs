using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheHubManager : MonoBehaviour
{
    public static TheHubManager instance;
    public GameObject fadeScreen, mainMenu, optionsMenu, pauseMenu;
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
        mainMenu.SetActive(false);
        FindObjectOfType<PlayerShooting>().shooting = false;
        FindObjectOfType<PlayerMovement>().transform.position = playerStartPosition.transform.position;


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
                if (IsSavedScene.instance.isContinue == false && isSaved == false)
                {
                    //FindObjectOfType<PlayerMovement>().transform.position = playerStartPosition.transform.position;
                    
                }
                else if (IsSavedScene.instance.isContinue == true)
                {
                    GameManager.instance.LoadData();
                    IsSavedScene.instance.isContinue = false;
                    
                }

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
