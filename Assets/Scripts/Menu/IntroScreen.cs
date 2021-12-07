using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScreen : MonoBehaviour
{
    public float introScreenTime, exitScreenTime, intrOlteanuScreenTime, exitOlteanuScreenTime , skypButtonTime;
    private float counterIntroScreen, counterExitScreen, counterIntrOlteanuScreen, counterExitOlteanuScreen, counterSkypButton;
    public float waitForNextScene, waitToLoadOlteanu;
    public GameObject godzilla, olteanu ,skyp;

    void Start()
    {
        godzilla.SetActive(true);
        counterIntroScreen = introScreenTime;
        //PauseMenu.instance.isPause = false;
        
    }
    
    void Update()
    {        
        if (counterIntroScreen > 0)
        {
            counterIntroScreen -= Time.deltaTime;
            if(counterIntroScreen <= 0)
            {
                IntroUIFade.instance.FadeFromBlack();
                counterExitScreen = exitScreenTime;
               // StartCoroutine(IntroOlteanuCo());
            }
        }
        

        if (counterExitScreen > 0)
        {
            counterExitScreen -= Time.deltaTime;
            if(counterExitScreen <= 0)
            {
                IntroUIFade.instance.FadeToBlack();
                StartCoroutine(IntroOlteanuCo());
                counterIntrOlteanuScreen = intrOlteanuScreenTime;
            }
        }

        if (counterIntrOlteanuScreen > 0)
        {
            counterIntrOlteanuScreen -= Time.deltaTime;
            if (counterIntrOlteanuScreen <= 0)
            {
                IntroUIFade.instance.FadeFromBlack();
                counterExitOlteanuScreen = exitOlteanuScreenTime;
            }
        }

        if (counterExitOlteanuScreen > 0)
        {
            counterExitOlteanuScreen -= Time.deltaTime;
            if (counterExitOlteanuScreen <= 0)
            {
                IntroUIFade.instance.FadeToBlack();
                StartCoroutine(ChangeSceneCo());
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            IntroUIFade.instance.FadeToBlack();
            StartCoroutine(SkypCo());

        }
    }

    private IEnumerator ChangeSceneCo()
    {
        yield return new WaitForSeconds(waitForNextScene);
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator IntroOlteanuCo()
    {
        yield return new WaitForSeconds(waitToLoadOlteanu);
        godzilla.SetActive(false);
        olteanu.SetActive(true);
        //counterIntrOlteanuScreen = intrOlteanuScreenTime;
    }

    public void SkypScene()
    {
        IntroUIFade.instance.FadeToBlack();
        StartCoroutine(SkypCo());        
    }

    private IEnumerator SkypCo()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }
}
