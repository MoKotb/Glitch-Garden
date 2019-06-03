using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audio;

    void Start()
    {
        DontDestroyOnLoad(this);
        audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefsController.GetVolume();
    }

    public void SetVolume(float volume)
    {
        audio.volume = volume;
    }

}
