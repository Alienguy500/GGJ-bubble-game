using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public float countDown;
    // Start is called before the first frame update
    void Start()
    {
        countDown = 240f;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown < 0)
        {
            Time.timeScale = 0;
        }
    }
}
