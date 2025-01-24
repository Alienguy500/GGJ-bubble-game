using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] MusicManager musicManager;
    [SerializeField] CountDown countDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && musicManager.GetCurrentTrack() >= 5)
        {
            other.gameObject.transform.position = new Vector3 (-79, 4, 32);
            countDown.countDown = 5;
        }
    }
}
