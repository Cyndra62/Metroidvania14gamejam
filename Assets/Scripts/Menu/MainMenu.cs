using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public float enterSceneTime;
    private float counterEnterScene;
    public float endTime;
    public GameObject fadeScreen;
    [SerializeField] GameObject continueButton;
    [SerializeField] public GameObject mainMenu;
    public GameObject uiHealthVisual, uiHalosVisual;
    
    
    
    
    private void Start()
    {
        fadeScreen.SetActive(true);
        mainMenu.SetActive(true);
        //FindObjectOfType<PlayerShooting>().shooting = true;
        //FindObjectOfType<PlayerShooting>()._canShoot = false;
        if (PlayerPrefs.HasKey("Current_scene"))
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }

        //theSprite.raycastTarget = true;
        counterEnterScene = enterSceneTime;
    }

    private void Update()
    {
        if(counterEnterScene > 0)
        {
            counterEnterScene -= Time.deltaTime;
            if(counterEnterScene <= 0)
            {
                UiFade.instance.FadeFromBlack();
                StartCoroutine(RaycastTargetCo());
                //Time.timeScale = 1f;
            }
        }

        /*if(IsSavedScene.instance.canShoot)
        {
            FindObjectOfType<PlayerShooting>().shooting = true;
            FindObjectOfType<PlayerShooting>()._canShoot = false;
        }*/

       //PauseMenu.instance.isPause = false;
    }

    public void QuitGame()
    {
        UiFade.instance.FadeToBlack();
        StartCoroutine(QuitGameCo());
    }

    private IEnumerator QuitGameCo()
    {
        yield return new WaitForSeconds(endTime);
        Application.Quit();
    }

    private IEnumerator RaycastTargetCo()
    {
        yield return new WaitForSeconds(endTime);
        //theSprite.raycastTarget = false;
    }

    public void NewGame()
    {
        UiFade.instance.FadeToBlack();
        PlayerPrefs.DeleteAll();
        Player.instance.areaTransitionName = "Start";
        IsSavedScene.instance.isContinue = true;
        IsSavedScene.instance.switchIsOn1ToyBox = false;
        IsSavedScene.instance.switchIsOn2UnderTheBed = false;
        IsSavedScene.instance.switchIsOn3UnderTheBed = false;
        IsSavedScene.instance.switchIsOn01DoorUnder = false;
        IsSavedScene.instance.switchIsOn02DoorUnder = false;
        IsSavedScene.instance.sUnderOnPl1 = false;
        IsSavedScene.instance.sUnderDoorOff3 = false;
        IsSavedScene.instance.sTheHub2 = false;
        IsSavedScene.instance.switchIsOn = false;
        IsSavedScene.instance.canShoot = true;
        IsSavedScene.instance.gateSave1 = true;
        IsSavedScene.instance.gateSave2 = false;
        IsSavedScene.instance.gateSave3 = false;
        IsSavedScene.instance.gateSave4 = false;
        StartCoroutine(NewGameCo());

    }

    private IEnumerator NewGameCo()
    {
        yield return new WaitForSeconds(endTime);
        mainMenu.SetActive(false);
        SceneManager.LoadScene("TheHub");
       
    }

    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("Current_scene"));
        //IsSavedScene.instance.isContinue = true;
        //GameManager.instance.LoadData();
        IsSavedScene.instance.isContinue = false;
        uiHalosVisual.SetActive(true);
        uiHealthVisual.SetActive(true);
        
    }

   /* public void OptionMenu()
    {
        optionMenu.SetActive(true);
    }*/
}