using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private CountDown countDown;
    // Start is called before the first frame update
    void Start()
    {
        countDown = GameObject.Find("GameManager").GetComponent<CountDown>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            countDown.countDown = 0f;
        }
    }
}
