using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HalosColorChange : MonoBehaviour
{
    public static HalosColorChange instance;
    public GameObject redOff;
    public GameObject greenOff;
    public GameObject blueOff;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        IsRed();
        IsGreen();
        IsBlue();
    }

    public void IsRed()
    {
        if(!IsSavedScene.instance.redOff)
        {
            redOff.SetActive(false);
            greenOff.SetActive(true);
            blueOff.SetActive(true);

        }
    }
    public void IsGreen()
    {
        if (!IsSavedScene.instance.greenOff)
        {
            redOff.SetActive(true);
            greenOff.SetActive(false);
            blueOff.SetActive(true);
        }
    }
    public void IsBlue()
    {
        if (!IsSavedScene.instance.blueOff)
        {
            redOff.SetActive(true);
            greenOff.SetActive(true);
            blueOff.SetActive(false);
        }
    }
}
