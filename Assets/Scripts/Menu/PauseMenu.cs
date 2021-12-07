using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public string mainMenu;
    [SerializeField] public float waitToChangeScene;
    public bool isPause;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (IsSavedScene.instance.canShoot)
        {
            FindObjectOfType<PlayerShooting>().shooting = true;
            FindObjectOfType<PlayerShooting>()._canShoot = false;
        }
        else
        {
            FindObjectOfType<PlayerShooting>().shooting = false;
            FindObjectOfType<PlayerShooting>()._canShoot = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
           PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if (isPause)
        {
            //PlayerMovement.instance.stopInput = true;
            isPause = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            IsSavedScene.instance.canShoot = false;
        }
        else
        {
            //PlayerMovement.instance.stopInput = false;
            isPause = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            IsSavedScene.instance.canShoot = true;

        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        UiFade.instance.FadeToBlack();
        //PlayerMovement.instance.areaTransitionName = "";
        StartCoroutine(MainMenuCo());
    }

    private IEnumerator MainMenuCo()
    {
        yield return new WaitForSeconds(waitToChangeScene);
        SceneManager.LoadScene(mainMenu);
    }

    public void SaveGame()
    {
        GameManager.instance.SaveData();
        IsSavedScene.instance.isContinue = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
