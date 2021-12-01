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
    public Image theSprite;
    [SerializeField] GameObject continueButton;
    //[SerializeField] public GameObject optionMenu;
    
    
    
    
    private void Start()
    {

        if(PlayerPrefs.HasKey("Current_scene"))
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }

        theSprite.raycastTarget = true;
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
       PauseMenu.instance.isPause = false;
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
        theSprite.raycastTarget = false;
    }

    public void NewGame()
    {
        UiFade.instance.FadeToBlack();
        PlayerPrefs.DeleteAll();
        IsSavedScene.instance.isContinue = false;
        StartCoroutine(NewGameCo());

    }

    private IEnumerator NewGameCo()
    {
        yield return new WaitForSeconds(endTime);
        //mainMenu.SetActive(false);
        SceneManager.LoadScene("TheHub");
       
    }

    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("Current_scene"));
        //IsSavedScene.instance.isContinue = true;
        //GameManager.instance.LoadData();
        IsSavedScene.instance.isContinue = true;
    }

   /* public void OptionMenu()
    {
        optionMenu.SetActive(true);
    }*/
}