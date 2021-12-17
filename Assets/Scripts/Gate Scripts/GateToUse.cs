using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateToUse : MonoBehaviour
{
    public static GateToUse instance;
    public string gateToLoad;
    public string areaTransitionName;
    public float waitToFade;
    public bool gate1, gate2, gate3, gate4;
    

    void Start()
    {
        instance = this;
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && gate1 && IsSavedScene.instance.gateSave1)
        {
            UiFade.instance.FadeToBlack();
            Player.instance.areaTransitionName = areaTransitionName;
            Player.instance.stopInput = true;
            StartCoroutine(TransitionCo());
        }
        if (other.tag == "Player" && gate2 && IsSavedScene.instance.gateSave2)
        {
            UiFade.instance.FadeToBlack();
            Player.instance.areaTransitionName = areaTransitionName;
            Player.instance.stopInput = true;
            StartCoroutine(TransitionCo());
        }
        if (other.tag == "Player" && gate3 && IsSavedScene.instance.gateSave3)
        {
            UiFade.instance.FadeToBlack();
            Player.instance.areaTransitionName = areaTransitionName;
            Player.instance.stopInput = true;
            StartCoroutine(TransitionCo());
        }
        if (other.tag == "Player" && gate4 && IsSavedScene.instance.gateSave4)
        {
            UiFade.instance.FadeToBlack();
            Player.instance.areaTransitionName = areaTransitionName;
            Player.instance.stopInput = true;
            StartCoroutine(TransitionCo());
        }
    }

    private IEnumerator TransitionCo()
    {
        yield return new WaitForSeconds(waitToFade);
        Player.instance.stopInput = false;
        SceneManager.LoadScene(gateToLoad);

    }
}
