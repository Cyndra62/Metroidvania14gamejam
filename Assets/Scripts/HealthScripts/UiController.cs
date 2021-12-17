using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public static UiController instance;
    public Image harth1, harth2, harth3, harth4;
    public Sprite hartFull, hartEmpty;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateHealthDisplay()
    {
        switch (PlayerHealtController.instance.currentHealt)
        {
            case 4:
                harth1.sprite = hartFull;
                harth2.sprite = hartFull;
                harth3.sprite = hartFull;
                harth4.sprite = hartFull;
                break;
            case 3:
                harth1.sprite = hartFull;
                harth2.sprite = hartFull;
                harth3.sprite = hartFull;
                harth4.sprite = hartEmpty;
                break;
            case 2:
                harth1.sprite = hartFull;
                harth2.sprite = hartFull;
                harth3.sprite = hartEmpty;
                harth4.sprite = hartEmpty;
                break;
            case 1:
                harth1.sprite = hartFull;
                harth2.sprite = hartEmpty;
                harth3.sprite = hartEmpty;
                harth4.sprite = hartEmpty;

                break;
            case 0:
                harth1.sprite = hartEmpty;
                harth2.sprite = hartEmpty;
                harth3.sprite = hartEmpty;
                harth4.sprite = hartEmpty;
                break;
            
            default:
                harth1.sprite = hartEmpty;
                harth2.sprite = hartEmpty;
                harth3.sprite = hartEmpty;
                harth4.sprite = hartEmpty;
                break;

        }
    }
}
