using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class VanController : MonoBehaviour
{
    public Animator[] SoapSet1;
    public Animator[] SoapSet2;
    public Animator VanBubbles;
    private int Count;

    public Transform Van;
    public Transform EndLocation;
    float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
    }

    // Update is called once per frame
    public void UpdateAnimations()
    {
        if(Count == 1)
        {
            VanBubbles.SetTrigger("Activate");
        }
        if (Count == 2)
        {
            foreach (Animator anim in SoapSet1)
            {
                anim.SetTrigger("Activate");
            }
        }
        if (Count == 3)
        {
            foreach (Animator anim in SoapSet2)
            {
                anim.SetTrigger("Activate");
            }
        }
        if(Count == 4)
        {
            Speed = 0.5f;
        }
        Count++;
    }

    IEnumerator MoveVehicle()
    {
        while (true)
        {
            while ((EndLocation.transform.position - Van.transform.position).sqrMagnitude > 0.01f)
            {
                Van.transform.position = Vector3.MoveTowards(Van.transform.position, EndLocation.transform.position, Speed * Time.fixedDeltaTime);
                yield return null;
            }
        }
    }
}
