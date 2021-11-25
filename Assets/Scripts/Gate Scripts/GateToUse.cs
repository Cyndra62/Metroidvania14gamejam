using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateToUse : MonoBehaviour
{
    public string gateToLoad;
    public string areaTransitionName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(gateToLoad);
            PlayerMovement.instance.areaTransitionName = areaTransitionName;
        }
    }
}
