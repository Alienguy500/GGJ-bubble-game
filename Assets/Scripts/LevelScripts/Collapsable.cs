using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collapsable : MonoBehaviour
{

    public IEnumerator Break()
    {
        GetComponent<Animator>().SetTrigger("Crack");
        yield return new WaitForSeconds(1);
        GetComponent<Animator>().SetTrigger("Break");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
