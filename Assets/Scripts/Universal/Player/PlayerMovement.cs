using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance; //used to find a position forsprites to look towards, in this case the player ~ Zach

    public CharacterController controller;
    public float Movement;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpeHeight = 3f;

    public float DownForce;
    public Transform groundCheck;
    public float groundDistance = 0.8f;
    public LayerMask groundMask;
    

    Vector3 velocity;
    public bool isGrounded;

    private void Awake()
    {
        instance = this; //initializes the instance ~ Zach
    }
    // Update is called once per frame
    void Update()
    {

        if (isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask))
        {
            velocity.y = gravity;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        // get move direction
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //get a Vector3 and set it to the direction of movement
        Vector3 move = transform.right * x + transform.forward * z;

        //apply Vector3 to character controller
        //velocity = move * speed * Time.deltaTime;

        //if jumped and is grounded, Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpeHeight * -2f * gravity);
        }
        // apply gravity
        //DownForce = velocity.y += gravity * Time.deltaTime;
        
        //DownForce = Mathf.Clamp(DownForce, -10, 10);
        //controller.Move(velocity * Time.deltaTime);
    }
   
}
