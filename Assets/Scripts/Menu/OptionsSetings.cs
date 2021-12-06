using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsSetings : MonoBehaviour
{
    public static OptionsSetings instance;

    public AudioMixer audioMixer;

    private void Awake()
    {
        instance = this;
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetBackgroundVolume(float volume)
    {
        audioMixer.SetFloat("Background", volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX", volume);
    }
}
