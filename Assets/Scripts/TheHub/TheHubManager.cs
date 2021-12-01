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
    public bool isContinue;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        mainMenu.SetActive(false);
        

        if(IsSavedScene.instance.isContinue == true)
        {
            GameManager.instance.LoadData();
        }
        else
        {
            FindObjectOfType<PlayerMovement>().transform.position = playerStartPosition.transform.position;
        }
        counterInLevel = inLevelTime;
        fadeScreen.SetActive(true);
        //IsContinue();
    }

    private void Update()
    {
        if(counterInLevel > 0)
        {
            counterInLevel -= Time.deltaTime;
            if(counterInLevel <= 0)
            {
                //IsContinue();
                if (IsSavedScene.instance.isContinue == true)
                {
                    GameManager.instance.LoadData();
                    IsSavedScene.instance.isContinue = false;
                }
                else if(!IsSavedScene.instance.isContinue == true)
                {
                    FindObjectOfType<PlayerMovement>().transform.position = playerStartPosition.transform.position;
                }
                UiFade.instance.FadeFromBlack();
            }
        }
    }

    public void IsContinue()
    {
        if (isContinue)
        {
            GameManager.instance.LoadData();

        }
        else
        {
           // FindObjectOfType<PlayerMovement>().transform.position = playerStartPosition.transform.position;
        }
    }
}
