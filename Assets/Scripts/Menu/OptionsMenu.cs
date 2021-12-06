using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public static OptionsMenu instance;
    [SerializeField] public GameObject optionMenu;
    [SerializeField] public bool isON;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isON = true;
        //optionMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }*/
    }

    public void Back()
    {
        if (isON)
        {
            isON = false;
            optionMenu.SetActive(true);
        }
        else
        {
            isON = true;
            optionMenu.SetActive(false);
        }
    }
}
