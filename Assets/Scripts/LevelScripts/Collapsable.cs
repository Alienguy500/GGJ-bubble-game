using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Collapsable : MonoBehaviour
{

    public IEnumerator Break()
    {
        GetComponent<Animator>().SetBool("SteppedOn", true);
        yield return new WaitForSeconds(1.75f);
        GetComponent<Animator>().SetBool("Broke", true);
        StartCoroutine(Repair());
    }
    IEnumerator Repair()
    {
        float Timer = 15;
        while (Timer > 0)
        {
            Timer -= Time.deltaTime;
            yield return null;
        }

        GetComponent<Animator>().SetBool("SteppedOn", false);
        GetComponent<Animator>().SetBool("Broke", false);
        GetComponent<Animator>().SetBool("Repair", true);
        yield return new WaitForSeconds(1);
        GetComponent<Animator>().SetBool("Repair", false);
    }
}
