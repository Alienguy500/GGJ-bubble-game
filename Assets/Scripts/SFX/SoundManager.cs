using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public float volume = 0;

    void Start()
    {
        volume = masterVolumeSlider.value;
    }
    public void ChangeMasterVolume()
    {
        AudioListener.volume = masterVolumeSlider.value;
        volume = masterVolumeSlider.value;
    }
}
