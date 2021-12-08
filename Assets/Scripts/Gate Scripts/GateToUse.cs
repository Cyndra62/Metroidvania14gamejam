using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateToUse : MonoBehaviour
{
    public string gateToLoad;
    public string areaTransitionName;
    public float waitToFade;

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && IsSavedScene.instance.canTravel == true)
        {
            UiFade.instance.FadeToBlack();
            PlayerMovement.instance.areaTransitionName = areaTransitionName;
            PlayerMovement.instance.stopInput = true;
            StartCoroutine(TransitionCo());
        }
    }

    private IEnumerator TransitionCo()
    {
        yield return new WaitForSeconds(waitToFade);
        PlayerMovement.instance.stopInput = false;
        SceneManager.LoadScene(gateToLoad);

    }
}
