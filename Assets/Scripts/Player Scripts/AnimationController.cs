using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void BubbleBlow(bool bol)
    {
        anim.SetBool("Bubbling", bol);
    }    
    // Update is called once per frame
    public void UpdateAnimations(Vector3 velocity, bool grounded, bool bubbled, bool jumped)
    {
        anim.SetBool("Bubbled", bubbled);
        anim.SetBool("Jumped", jumped);
        anim.SetInteger("xVelocity", (int)velocity.x);
        anim.SetInteger("yVelocity", (int)velocity.y);
        anim.SetBool("OnGround", grounded);
            if (velocity.x < 0)
                anim.SetBool("Mirror", true);
            else
                anim.SetBool("Mirror", false);

    }
}
