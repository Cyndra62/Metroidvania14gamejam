using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch4 : MonoBehaviour
{
    public static Switch4 instance;
    public GameObject platform;
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
        if (!IsSavedScene.instance.sTheHub2)
        {
            platform.SetActive(false);
            theSR.sprite = upSprite;
            hasSwitched = false;
        }
        else
        {
            platform.SetActive(true);
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
                platform.SetActive(true);

            }
            else
            {
                platform.SetActive(false);
            }


            theSR.sprite = downSprite;
            hasSwitched = true;
            IsSavedScene.instance.sTheHub2 = true;
        }
    }
}
