using UnityEngine;
using System.Collections;

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class playerControl : MonoBehaviour
{
    public static playerControl instance;

    public CharacterController characterController;

    public Animator anim;
    public GameObject jumpParticle;

    float tempTime;


    public float speed = 6.0f;
    public float jumpSpeed = 6.0f;
    public float gravity = 15.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        tempTime = Time.time;
       
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            anim.SetBool("jump", false);
            if ((Time.time - tempTime) <= 10) anim.SetBool("walk", true);
            else anim.SetBool("running", true);
            // We are grounded, so recalculate
            // move direction directly from axes
            //characterController.Move(Vector3.forward);
            moveDirection = new Vector3(0, 0.0f, (Time.time - tempTime) / 10);
            moveDirection *= speed;

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 particlePosition = new Vector3(0, 0, -1);
                anim.SetBool("jump", true);
                SM.instance.jumpSound();
                Instantiate(jumpParticle, anim.transform.position , anim.transform.rotation);

                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);



    }
}