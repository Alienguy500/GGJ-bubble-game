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
        for (int i = 0; i < tracks.Length; i++)
        {
            SetTrackMute(i, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTrackMute(int trackIndex, bool mute)
    {
        tracks[trackIndex].mute = mute;
    }
}
