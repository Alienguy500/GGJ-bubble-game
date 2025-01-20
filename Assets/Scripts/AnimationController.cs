using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;

    private float xVelocity;
    private float yVelocity;
    private bool inBubble;
    private bool isPressingButton;
    private bool timedOut;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void UpdateAnimations(Vector3 velocity, bool bubbled, bool pressingButton, bool timedOut)
    {
        //Timeout, Button press, Bubble, Jumping, Falling, Running, Walking, Idle 
        if(timedOut)
        {
            //TimeOut
        }
        if (isPressingButton)
        {
            //Button Press Actions
            return;
        }
        else if (inBubble)
        {
            //Bubble Actions
            return;
        }
        else
        {
            if (velocity.y > 0)
            {
                //Jump
                return;
            }
            else if (velocity.y < 0)
            {
                //Fall
                return;
            }
        }
        if(velocity.x < 0)
            anim.SetBool("Mirror", true);
        else
            anim.SetBool("Mirror", false);
        anim.SetInteger("xVelocity", (int)velocity.x);
    }
}
