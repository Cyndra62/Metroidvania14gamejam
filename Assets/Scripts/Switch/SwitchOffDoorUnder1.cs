using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOffDoorUnder1 : MonoBehaviour
{
    public static SwitchOffDoorUnder1 instance;
    public GameObject objectToSwitch;
    private SpriteRenderer theSR;
    public Sprite downSprite, upSprite;
    private bool hasSwitched;
    public bool activateOnSwitch;


    void Start()
    {
        instance = this;
        theSR = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (!IsSavedScene.instance.switchIsOn01DoorUnder)
        {
            objectToSwitch.SetActive(true);
            theSR.sprite = upSprite;
            hasSwitched = false;
        }
        else
        {
            objectToSwitch.SetActive(false);
            theSR.sprite = downSprite;
            hasSwitched = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !hasSwitched)
        {

            if (activateOnSwitch)
            {
                objectToSwitch.SetActive(false);

            }
            else
            {
                objectToSwitch.SetActive(true);
            }


            theSR.sprite = downSprite;
            hasSwitched = true;
            IsSavedScene.instance.switchIsOn01DoorUnder = true;
        }
    }
}
