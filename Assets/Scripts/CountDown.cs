using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    public float countDown;
    public TMP_Text countdownDisplay;
    public GameObject endSpotlight;
    public AudioSource losingSound;
    bool soundPlayed = false;

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown >= 0)
        {
            countdownDisplay.text = "Time Left: "+Mathf.RoundToInt(countDown).ToString();
        }
        else
        {
            if (!soundPlayed)
            {
                GameManager.Instance.musicManager.StopAllTracks();
                losingSound.Play();
                soundPlayed = true;
                endSpotlight.SetActive(true);
                StartCoroutine(DelayGameEnd(5));
            }
        }
        IEnumerator DelayGameEnd(float delay)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
