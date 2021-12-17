using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NormalGate : MonoBehaviour
{
    public static NormalGate instance;
    public string gateToLoad;
    public string areaTransitionName;
    public float waitToFade;

    void Start()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" )
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
