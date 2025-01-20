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

    //Players input
    private Vector3 playerMoveInput;


    private GameManager manager;
    private AnimationController controller;

    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float lookSpeed;
    //Bools to keep track what state they are currently in
    private float rotX;
    float runTimer;
    [SerializeField] float landTimer;
    public enum MoveState { IDLE, WALK, DASH, SNEAK, DEATH };
    private MoveState moveState;

    private void Start()
    {
        //Set the state to idle
        moveState = MoveState.IDLE;
        rb = transform.GetComponent<Rigidbody>();
        controller = transform.GetChild(0).GetComponent<AnimationController>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    //Update once a frame
    void Update()
    {
        if (manager.GetTimer() > 0)
        {

            playerMoveInput = new(0, 0, Input.GetAxis("Horizontal"));
            //Gets the camera's input and run its function
            //Jump Function
            if (Input.GetKeyDown(KeyCode.Space) && landTimer <= 0)
            {
                //Check if the feet GameObject are on the ground that has a layer called 'Ground'
                if (Physics.CheckSphere(feetPosition.position, 0.1f, floorMask))
                {
                    Jump();
                }
            }
            if (landTimer > 0 && Physics.CheckSphere(feetPosition.position, 0.1f, floorMask))
            {
                rb.velocity = Vector3.zero;
                landTimer -= Time.deltaTime;
                controller.UpdateAnimations(playerMoveInput, true, false, false, false);
                playerMoveInput = new(0, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
                speed = 10;
            if (playerMoveInput == Vector3.zero && speed == 10)
                runTimer -= Time.deltaTime;
            if (runTimer <= 0)
            {
                speed = 5;
                runTimer = 0.125f;
            }
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
        rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        landTimer = 0.65f;
    }
    void MovePlayer()
    {
        //Total Move Direction for the frame
        Vector3 MoveDir = transform.TransformDirection(playerMoveInput) * speed;
        //Setting the Y velocity aswell
        MoveDir.y = rb.velocity.y;
        //Calculates and then applies then input with rigidbody's Physics
        controller.UpdateAnimations(MoveDir, Physics.CheckSphere(feetPosition.position, 0.1f, floorMask), false, false, false);
        rb.MovePosition(transform.position + MoveDir * Time.deltaTime);
    }
}
