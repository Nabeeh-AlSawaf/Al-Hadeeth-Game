using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioSource source;
    
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    public static void playBackgroundMusic()
    {
        source.clip = GlobalVariables.backGroundMusic;
        source.volume = GlobalVariables.settings.musicLevel;
        source.Play();
    }

}
