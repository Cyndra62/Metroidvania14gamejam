using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScreen : MonoBehaviour
{
    public float introScreenTime, exitScreenTime, intrOlteanuScreenTime, exitOlteanuScreenTime;
    private float counterIntroScreen, counterExitScreen, counterIntrOlteanuScreen, counterExitOlteanuScreen;
    public float waitForNextScene, waitToLoadOlteanu;
    public GameObject godzilla, olteanu;

    void Start()
    {
        godzilla.SetActive(true);
        counterIntroScreen = introScreenTime;
    }
    
    void Update()
    {
        if(counterIntroScreen > 0)
        {
            counterIntroScreen -= Time.deltaTime;
            if(counterIntroScreen <= 0)
            {
                UiFade.instance.FadeFromBlack();
                counterExitScreen = exitScreenTime;
               // StartCoroutine(IntroOlteanuCo());
            }
        }

        if(counterExitScreen > 0)
        {
            counterExitScreen -= Time.deltaTime;
            if(counterExitScreen <= 0)
            {
                UiFade.instance.FadeToBlack();
                StartCoroutine(IntroOlteanuCo());
                counterIntrOlteanuScreen = intrOlteanuScreenTime;
            }
        }

        if (counterIntrOlteanuScreen > 0)
        {
            counterIntrOlteanuScreen -= Time.deltaTime;
            if (counterIntrOlteanuScreen <= 0)
            {
                UiFade.instance.FadeFromBlack();
                counterExitOlteanuScreen = exitOlteanuScreenTime;
            }
        }

        if (counterExitOlteanuScreen > 0)
        {
            counterExitOlteanuScreen -= Time.deltaTime;
            if (counterExitOlteanuScreen <= 0)
            {
                UiFade.instance.FadeToBlack();
                StartCoroutine(ChangeSceneCo());
            }
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
}
