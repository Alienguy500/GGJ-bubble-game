using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Transform platform;
    private Transform pointA;
    private Transform pointB;
    [SerializeField] private float speed;
    [SerializeField] private float Delay;
    [SerializeField] private Vector3 Distance;
    // Start is called before the first frame update
    void Start()
    {
        platform = transform.GetChild(0);
        pointA = transform.GetChild(1);
        pointB = transform.GetChild(2);

        platform.position = pointA.position;
        Vector3 targetPosition = pointB.position;
        StartCoroutine(MovePlatform(targetPosition));
    }


    
    IEnumerator MovePlatform(Vector3 targetPos)
    {
        while (true)
        {
            while ((targetPos - platform.transform.position).sqrMagnitude > 0.01f)
            {
                Distance = platform.transform.position - Vector3.MoveTowards(platform.transform.position, targetPos, speed * Time.fixedDeltaTime);
                platform.transform.position = Vector3.MoveTowards(platform.transform.position, targetPos, speed * Time.fixedDeltaTime);
                yield return null;
            }
            Distance = Vector3.zero;
            targetPos = targetPos == pointA.position ? pointB.position : pointA.position;

            yield return new WaitForSeconds(Delay);
        }
    }

    public Vector3 GetDisplacement()
    {
        return Distance;
    }
}
