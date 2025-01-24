using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //Getting the camera and where the character's physics body and feet gameobject. Also what layer the feet will interact with.
    [SerializeField] private LayerMask floorMask;
    [SerializeField] private Transform feetPosition;
    [SerializeField] private Transform playerCamera;
    private Rigidbody rb;
    private Vector3 playerMoveInput;


    private GameManager manager;
    private AnimationController controller;

    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    //Timers to keep track what state they are currently in
    float runTimer;
    float landTimer;
    [SerializeField] float bubbleTimer;
    [SerializeField] bool inBubble;
    float multiplier;
    float bubbleDrag;
    bool jump;
    bool jumped;
    [SerializeField] bool onFan;
    [SerializeField] Vector3 fanForce;
    [SerializeField] Vector3 displacement;
    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        controller = transform.GetChild(0).GetComponent<AnimationController>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    //Update once a frame
    void Update()
    {
        bool grounded = Physics.CheckSphere(feetPosition.position, 0.1f, floorMask);
        if (manager.GetTimer() > 0)
        {
            controller.BubbleBlow(false);
            //Movement
            playerMoveInput = new(0, 0, Input.GetAxisRaw("Horizontal"));
            //Jump
            if (Input.GetKeyDown(KeyCode.Space) && landTimer <= 0)
            {
                //Check if the feet GameObject are on the ground that has a layer called 'Ground'
                if (grounded)
                    Jump();
            }
            //Run
            if (Input.GetKeyDown(KeyCode.LeftShift))
                speed = 10;
            //Bubbling
            if (Input.GetKeyDown(KeyCode.Q) && !inBubble && !grounded)
            {
                controller.BubbleBlow(true);
                inBubble = true;
                if (rb.useGravity && rb.velocity.y < 0)
                {
                    rb.useGravity = false;
                    bubbleTimer = 3f;
                    bubbleDrag = 0;
                }
            }
            //Bubble Timer to slowly Lower the player, getting faster the longer they are in the bubble
            if (bubbleTimer > 0)
            {
                bubbleTimer -= Time.deltaTime;
            }
            if (bubbleTimer <= 0 && inBubble)
            {
                bubbleDrag += Time.deltaTime;
                rb.AddForce(Vector3.down * bubbleDrag);
                if(grounded && inBubble)
                {

                    inBubble = false;
                    rb.useGravity = true;
                }
            }
            //Landing Timer to hold the player in place once they land
            if (landTimer > 0)
            {
                if (grounded)
                {
                    landTimer -= Time.deltaTime;
                    rb.velocity = Vector3.zero;
                    playerMoveInput = new(0, 0, 0);
                }
            }
            //Runner Timer to only disable when idling (allows switching while keeping running)
            if (playerMoveInput == Vector3.zero && speed == 10)
            {
                runTimer -= Time.deltaTime;
                if (runTimer <= 0)
                {
                    speed = 7;
                    runTimer = 0.125f;
                }
            }
            if(rb.velocity.y < 0 && jumped)
                jumped = false;
            //Animation Data Every Frame
            Vector2 displacement = new(playerMoveInput.z * speed, rb.velocity.y);
            controller.UpdateAnimations(displacement, grounded, inBubble, jumped);
        }
    }
    //FixedUpdate can run multiple times per frame
    private void FixedUpdate()
    {
        if (manager.GetTimer() > 0)
        {
            MovePlayer();
        }
    }
    void Jump()
    {
        jump = true;
        jumped = true;
        landTimer = 0.85f;
    }
    void MovePlayer()
    {
        if (inBubble)
            multiplier = 1.5f;
        else
            multiplier = 1f;
        if (onFan && fanForce != Vector3.zero)
        {
            if (inBubble)
                rb.AddForce(fanForce * multiplier, ForceMode.Force);
            else
                rb.AddForce(fanForce, ForceMode.Force);
            landTimer = 0.85f;
        }
        //Total Move Direction for the frame
        Vector3 MoveDir = transform.TransformDirection(playerMoveInput) * speed;
        //Setting the Y velocity aswell
        MoveDir.y = rb.velocity.y;
        //Calculates and then applies then input with rigidbody's Physics

        rb.MovePosition(transform.position + (MoveDir * Time.deltaTime) + (-displacement * 5));
        if (jump)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
        jump = false;
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crumble") && collision != null)
        {
            StartCoroutine(collision.gameObject.transform.parent.GetComponent<Collapsable>().Break());
        }
        if (collision.gameObject.CompareTag("Moving"))
        {
            displacement = collision.gameObject.GetComponentInParent<MovingPlatform>().GetDisplacement();
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Moving"))
        {
            displacement = Vector3.zero;
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fan"))
        {
            fanForce = other.GetComponent<FanController>().GetForce();
            onFan = true;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Fan"))
        {
            fanForce = other.GetComponent<FanController>().GetForce();
            onFan = true;
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Fan"))
        {
            onFan = false;
        }
    }

}
