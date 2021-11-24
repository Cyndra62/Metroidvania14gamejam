using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public float enterSceneTime;
    private float counterEnterScene;
    public float endTime;
    public Image theSprite;

    private void Start()
    {
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
            }
        }
    }

    private void QuitGame()
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
}
