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
    [SerializeField] public Transform newGameposition;
    [SerializeField] public GameObject player;

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

        /*if (PlayerMovement.instance.transform.position != newGameposition.transform.position)
        {
            PlayerMovement.instance.transform.position = newGameposition.transform.position;
        }*/
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
            }
        }
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
        StartCoroutine(NewGameCo());

    }

    private IEnumerator NewGameCo()
    {
        yield return new WaitForSeconds(endTime);
        SceneManager.LoadScene("TheHub");
    }

    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("Current_scene"));
        //GameManager.instance.LoadData();
    }
}
