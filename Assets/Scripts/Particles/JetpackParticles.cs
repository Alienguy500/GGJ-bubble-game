using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackParticles : MonoBehaviour
{
    ParticleSystem particleSystem;
    AudioSource soundEffect;
    bool spacePressed;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        soundEffect = GetComponent<AudioSource>();
        spacePressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Jump") != 0)
        {
            particleSystem.Play();
            if (!spacePressed)
            {
                soundEffect.Play();
            }
            spacePressed = true;
        }
        else
        {
            soundEffect.Stop();
            spacePressed = false;
        }
    }
}
