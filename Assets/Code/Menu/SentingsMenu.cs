using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SentingsMenu : MonoBehaviour
{


    //volume seting
    public AudioMixer audioMixer;
    public float volume;
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }


    //quality setting
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

}
