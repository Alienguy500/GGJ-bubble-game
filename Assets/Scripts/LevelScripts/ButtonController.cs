using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    int isOnHash;
    bool isisOnOn;
    public bool isOn = false;
    bool collidingWithPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //isOnHash = animator.StringToHash("isOn");

        isisOnOn = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isOn = animator.GetBool("isOn");
        if (isOn)
        {
            if (!isisOnOn)
            {
                isisOnOn = true;
                audioSource.Play();
            }
        }
        else
        {
            if (isisOnOn)
            {
                isisOnOn = false;
                audioSource.Play();
            }
        }
        
        if (collidingWithPlayer)
        {
    
            if (Input.GetKey("e"))
            {
                animator.SetBool("isOn", true);
            }
            else
            {
                animator.SetBool("isOn", false);
            }
            
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collidingWithPlayer = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collidingWithPlayer = false;
        }
    }
}
