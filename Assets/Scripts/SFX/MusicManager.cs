using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicManager : MonoBehaviour
{
    public AudioSource[] tracks;
    private int currentTrack = 0;
    public TMP_Text progressMarker;
    public AudioSource losingSound;
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
    public void SetAllTracksMute(bool mute)
    {
        foreach (var track in tracks)
        {
            track.mute = mute;
            print("Muted");
        }
    }
    public void StopAllTracks()
    {
        foreach (var track in tracks)
        {
            track.enabled = false;
        }
    }
    public void SetTrackVolume(int trackIndex, float volume) // Volume can be anything from 0.0f to 1.0f
    {
        tracks[trackIndex].volume = volume;
    }
    public void PlayNextTrack()
    {
        currentTrack++;
        SetTrackMute(currentTrack, false);
        progressMarker.text = "Switches Flipped: " + currentTrack + "/5";
    }
}
