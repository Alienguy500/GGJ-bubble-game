using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    public float countDown;
    public TMP_Text countdownDisplay;
    public AudioSource losingSound;
    bool soundPlayed = false;

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        countdownDisplay.text = "Time Left: "+Mathf.RoundToInt(countDown).ToString();
        if (countDown < 0)
        {
            if (!soundPlayed)
            {
                GameManager.Instance.musicManager.StopAllTracks();
                losingSound.Play();
                soundPlayed = true;
            }
            Time.timeScale = 0;
        }
    }
}
