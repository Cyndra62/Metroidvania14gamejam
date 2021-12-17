using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public GameObject uihealth, uihalos;
    private void Start()
    {
        uihalos.SetActive(true);
        uihealth.SetActive(true);
    }
}
