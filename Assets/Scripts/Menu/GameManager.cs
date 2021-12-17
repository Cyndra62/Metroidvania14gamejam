using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float fadeSpeed, waitToRespawn;

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
        PlayerPrefs.SetFloat("Player_Position_x", FindObjectOfType<Player>().transform.position.x);
        PlayerPrefs.SetFloat("Player_Position_y", FindObjectOfType<Player>().transform.position.y);
        PlayerPrefs.SetFloat("Player_Position_z", FindObjectOfType<Player>().transform.position.z);
    }

    public void LoadData()
    {
        //currentHealth = PlayerPrefs.GetInt("Player_Health");
        //load position char
        //SceneManager.LoadScene(PlayerPrefs.GetString("Current_scene"));
        FindObjectOfType<Player>().transform.position = new Vector3(PlayerPrefs.GetFloat("Player_Position_x"), PlayerPrefs.GetFloat("Player_Position_y"), PlayerPrefs.GetFloat("Player_Position_z"));
       // PlayerMovement.instance.transform.position = new Vector3(PlayerPrefs.GetFloat("Player_Position_x"), PlayerPrefs.GetFloat("Player_Position_y"), PlayerPrefs.GetFloat("Player_Position_z"));
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
       // if() daca este isSavedScene un bool ca sa dau respawn la hub din ultimu nivel.
    }

    private IEnumerator RespawnCo()
    {
        FindObjectOfType<Player>().playerDeath.color = new Color(1, 1, 1, 0);
        //GameObject _dead =(GameObject)Instantiate(deadPlayer, PlayerControler.instance.theRB.transform.position, Quaternion.identity);
        //AudioManager.instance.StopMusic();
        yield return new WaitForSeconds(waitToRespawn - (1f / fadeSpeed));
        UiFade.instance.FadeToBlack();
        yield return new WaitForSeconds(waitToRespawn - (1f / fadeSpeed));
        UiFade.instance.FadeFromBlack();
        FindObjectOfType<Player>().playerDeath.color = new Color(1, 1, 1, 1);
        Player.instance.transform.position = FindObjectOfType<RespawnPoint>().transform.position;
        PlayerHealtController.instance.currentHealt = PlayerHealtController.instance.maxHealt;
        UiController.instance.UpdateHealthDisplay();
        //AudioManager.instance.PlayBGM(musicToPlay);
        /* if(BossTankController.instance.currentState != BossTankController.bossStates.ended )
         {
             AudioManager.instance.PlayBossMusic();
         }
         else
         {
             AudioManager.instance.PlayBGM(musicToPlay);
         }*/
    }
}
