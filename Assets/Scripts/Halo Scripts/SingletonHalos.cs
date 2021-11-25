using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonHalos : MonoBehaviour
{
    public static SingletonHalos instance;
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
}
