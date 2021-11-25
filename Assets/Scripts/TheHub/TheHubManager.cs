using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheHubManager : MonoBehaviour
{
    public GameObject fadeScreen;

    private void Start()
    {
        fadeScreen.SetActive(true);
    }
}
