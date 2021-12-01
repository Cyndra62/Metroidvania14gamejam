using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSavedScene : MonoBehaviour
{
    public static IsSavedScene instance;
    public bool isContinue;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }

        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        isContinue = false;
    }


}
