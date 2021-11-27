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
    [SerializeField] public Transform newGameposition;

    private void Start()
    {
        theSprite.raycastTarget = true;
        counterEnterScene = enterSceneTime;
        if (PlayerMovement.instance.transform.position != newGameposition.transform.position)
        {
            PlayerMovement.instance.transform.position = newGameposition.transform.position;
        }
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
        StartCoroutine(NewGameCo());

    }

    private IEnumerator NewGameCo()
    {
        yield return new WaitForSeconds(endTime);
        SceneManager.LoadScene("TheHub");
    }
}
