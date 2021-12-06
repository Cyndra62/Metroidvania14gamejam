using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
           SaveData();
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("Current_scene"));
            //TheHubManager.instance.isSaved = true;
            //LoadData();
        }
    }
    public void SaveData()
    {
        //PlayerPrefs.SetInt("Player_Health", currenthealth);
        //save position char
        //PlayerPrefs.SetFloat("Current_Audio_Master", OptionsSetings.instance.audioMixer.name.SetMasterVolume());
        PlayerPrefs.SetString("Current_scene", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetFloat("Player_Position_x", FindObjectOfType<PlayerMovement>().transform.position.x);
        PlayerPrefs.SetFloat("Player_Position_y", FindObjectOfType<PlayerMovement>().transform.position.y);
        PlayerPrefs.SetFloat("Player_Position_z", FindObjectOfType<PlayerMovement>().transform.position.z);
    }

    public void LoadData()
    {
        //currentHealth = PlayerPrefs.GetInt("Player_Health");
        //load position char
        //SceneManager.LoadScene(PlayerPrefs.GetString("Current_scene"));
        FindObjectOfType<PlayerMovement>().transform.position = new Vector3(PlayerPrefs.GetFloat("Player_Position_x"), PlayerPrefs.GetFloat("Player_Position_y"), PlayerPrefs.GetFloat("Player_Position_z"));
       // PlayerMovement.instance.transform.position = new Vector3(PlayerPrefs.GetFloat("Player_Position_x"), PlayerPrefs.GetFloat("Player_Position_y"), PlayerPrefs.GetFloat("Player_Position_z"));
    }
}
