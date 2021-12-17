using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSavedScene : MonoBehaviour
{
    public static IsSavedScene instance;
    public bool isContinue;
    public bool switchIsOn1ToyBox, switchIsOn2UnderTheBed, switchIsOn3UnderTheBed, switchIsOn, canShoot, canTravel, isSwitchOff, switchIsOn01DoorUnder, switchIsOn02DoorUnder;
    public bool sUnderOnPl1, sUnderDoorOff3, sTheHub2;

    [Header("Halos Configuration")]
    public bool redOff;
    public bool greenOff, blueOff;

    [Header("Gates available")]
    public bool gateSave1;
    public bool gateSave2, gateSave3, gateSave4;

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
        switchIsOn1ToyBox = false;
        switchIsOn2UnderTheBed = false;
        switchIsOn3UnderTheBed = false;
        switchIsOn01DoorUnder = false;
        switchIsOn02DoorUnder = false;
        sTheHub2 = false;
        sUnderDoorOff3 = false;
        sUnderOnPl1 = false;
        switchIsOn = false;
        canShoot = true;
        canTravel = true;
        isSwitchOff = false;
        redOff = false;
        greenOff = true;
        blueOff = true;
        gateSave1 = true;
        gateSave2 = false;
        gateSave3 = false;
        gateSave4 = false;
    }
    /*private void Update()
    {
        if(FindObjectOfType<PlayerShooting>()._ammoCount >= 2)
        {
            canTravel = true;
        }
        else
        {
            canTravel = false;
        }
    }*/


}
