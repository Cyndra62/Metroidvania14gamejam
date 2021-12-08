using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSavedScene : MonoBehaviour
{
    public static IsSavedScene instance;
    public bool isContinue;
    public bool switchIsOn, canShoot, canTravel;

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
        switchIsOn = false;
        canShoot = true;
        canTravel = true;
    }
    private void Update()
    {
        if(FindObjectOfType<PlayerShooting>()._ammoCount >= 2)
        {
            canTravel = true;
        }
        else
        {
            canTravel = false;
        }
    }


}
