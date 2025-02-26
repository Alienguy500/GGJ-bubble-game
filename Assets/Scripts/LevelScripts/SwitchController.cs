using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchController : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;
    int isOnHash;
    bool isisOnOn;
    public bool isOn = false;
    bool collidingWithPlayer = false;
    bool lockInput = false;
    public bool isButton = false;
    public GameObject marker;

    [Header("Drag a script here")]
    public UnityEvent valueChange;
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
                marker.SetActive(false);
                OnValueChange();
            }
        }
        else
        {
            if (isisOnOn)
            {
                isisOnOn = false;
                audioSource.Play();
                OnValueChange();
            }
        }
        
        if (collidingWithPlayer)
        {
            if (isButton)
            {
                animator.SetBool("isOn", true);
            }
            else
            {
                if (!lockInput)
                {
                    if (Input.GetKey("e"))
                    {
                        animator.SetBool("isOn", !isOn);
                        lockInput = true;
                    }
                }
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
    void OnValueChange()
    {
        valueChange.Invoke();
    }
}
