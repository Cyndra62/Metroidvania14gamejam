using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlatformUnder1 : MonoBehaviour
{
    public static SwitchPlatformUnder1 instance;
    public GameObject platform1, platform2, platform3
        ;
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
        if (!IsSavedScene.instance.sUnderOnPl1)
        {
            platform1.SetActive(false);
            platform2.SetActive(false);
            platform3.SetActive(false);
            theSR.sprite = upSprite;
            hasSwitched = false;
        }
        else
        {
            platform1.SetActive(true);
            platform2.SetActive(true);
            platform3.SetActive(true);
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
                platform1.SetActive(true);
                platform2.SetActive(true);
                platform3.SetActive(true);

            }
            else
            {
                platform1.SetActive(false);
                platform2.SetActive(false);
                platform3.SetActive(false);
            }


            theSR.sprite = downSprite;
            hasSwitched = true;
            IsSavedScene.instance.sUnderOnPl1 = true;
        }
    }
}
