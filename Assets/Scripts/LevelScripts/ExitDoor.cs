using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] MusicManager musicManager;
    [SerializeField] CountDown countDown;
    [SerializeField] Transform fakePlayer;
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
            other.gameObject.transform.position = fakePlayer.transform.position;
            fakePlayer.gameObject.SetActive(false);
            countDown.countDown = 5;
        }
    }
}
