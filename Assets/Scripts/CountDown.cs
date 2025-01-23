using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    public float countDown;
    public TMP_Text countdownDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        countDown = 240f;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        countdownDisplay.text = countDown.ToString();
        if (countDown < 0)
        {
            Time.timeScale = 0;
        }
    }
}
