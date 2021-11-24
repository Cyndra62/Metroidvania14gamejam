using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public int musicToPlay;
    public bool musicStarted;

    private void Update()
    {
        if (!musicStarted)
        {
            musicStarted = true;

            AudioManager.instance.PlayBGM(musicToPlay);
        }
    }
}
