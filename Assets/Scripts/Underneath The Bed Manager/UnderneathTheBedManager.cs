using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnderneathTheBedManager : MonoBehaviour
{
    public static UnderneathTheBedManager instance;
    public GameObject fadeScreen;
    public float inLevelTime;
    private float counterInLevel;
    public Transform playerSpawnPoint;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        counterInLevel = inLevelTime;
        fadeScreen.SetActive(true);
        
    }

    private void Update()
    {
        if (counterInLevel > 0)
        {
            counterInLevel -= Time.deltaTime;
            if (counterInLevel <= 0)
            {
                /*if ( PlayerPrefs.HasKey("Current_scene"))
                {
                    GameManager.instance.LoadData();
                }
                else
                {
                    FindObjectOfType<PlayerMovement>().transform.position = playerSpawnPoint.transform.position;
                }*/
                UiFade.instance.FadeFromBlack();
            }
        }
    }
}
