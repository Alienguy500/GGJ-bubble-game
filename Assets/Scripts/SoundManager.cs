using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public void ChangeMasterVolume()
    {
        AudioListener.volume = masterVolumeSlider.value;
    }
}
