using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    int isOnHash;
    bool isisOnOn;
    public bool isOn = false;
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
        bool isOn = animator.GetBool("isOn");
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
        if ()
        {
            animator.SetBool("isOn", Input.GetKeyDown("e"))
        }
    }
}
