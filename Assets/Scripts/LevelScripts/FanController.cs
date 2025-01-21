using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    [SerializeField] private int Delay;
    [SerializeField] private Vector2 Force;


    private ParticleSystem particles;
    [SerializeField] private Collider fanCollider;
    // Start is called before the first frame update
    void Start()
    {
        fanCollider = GetComponent<Collider>();
        particles = transform.GetChild(0).GetComponent<ParticleSystem>();
        StartCoroutine(FanRun());
    }

    IEnumerator FanRun()
    {
        float Timer = 15;
        while (true)
        {
            while (Timer > 0)
            {
                Timer -= Time.deltaTime;
                yield return null;
            }
            particles.Pause();

            yield return new WaitForSeconds(Delay);
            particles.Play();
            Timer = 15;
        }
    }

    public Vector2 GetForce() 
    {
        if (particles.isPlaying)
            return Force;
        else
            return new(0, 0);
    }
}
