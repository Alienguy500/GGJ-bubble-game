using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource[] tracks;
    // Start is called before the first frame update
    void Start()
    {
        tracks = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTrackMute(int trackIndex, bool mute)
    {
        tracks[trackIndex].mute = mute;
    }
    public void SetTrackVolume(int trackIndex, float volume) // Volume can be anything from 0.0f to 1.0f
    {
        tracks[trackIndex].volume = volume;
    }
}
