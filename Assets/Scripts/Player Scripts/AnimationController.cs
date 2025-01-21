using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;


    private bool inBubble;
    private bool isPressingButton;
    private bool timedOut;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void UpdateAnimations(Vector3 velocity, bool grounded, bool bubbled)
    {
        anim.SetBool("Bubbled", bubbled);
        anim.SetInteger("xVelocity", (int)velocity.x);
        anim.SetInteger("yVelocity", (int)velocity.y);
        anim.SetBool("OnGround", grounded);
            if (velocity.x < 0)
                anim.SetBool("Mirror", true);
            else
                anim.SetBool("Mirror", false);

    }
}
