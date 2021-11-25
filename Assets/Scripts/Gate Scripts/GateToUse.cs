using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateToUse : MonoBehaviour
{
    public string gateToLoad;
    public string areaTransitionName;
    public float waitToFade;
    public Rigidbody2D _rb;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
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
