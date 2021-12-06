using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButton : MonoBehaviour
{
    public static SwitchButton instance;
    public GameObject objectToSwitch;
    private SpriteRenderer theSR;
    public Sprite downSprite, upSprite;
    private bool hasSwitched;
    public bool activateOnSwitch;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsSavedScene.instance.switchIsOn)
        {
            objectToSwitch.SetActive(true);
            theSR.sprite = downSprite;
            hasSwitched = true;
        }
        else
        {
            objectToSwitch.SetActive(false);
            theSR.sprite = upSprite;
            hasSwitched = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !hasSwitched)
        {

            if (activateOnSwitch)
            {
                objectToSwitch.SetActive(true);

            }
            else
            {
                objectToSwitch.SetActive(false);
            }


            theSR.sprite = downSprite;
            hasSwitched = true;
            IsSavedScene.instance.switchIsOn = true;
        }
    }
}
