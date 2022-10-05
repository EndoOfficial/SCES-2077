using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStick : MonoBehaviour
{

    public Transform groundCheck;
    public float groundDistance = 0.8f;
    public LayerMask groundMask;
    bool groundedToggle;
    public bool isGrounded;

    private void Update()
    {
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, out RaycastHit hitinfo, groundDistance, groundMask); // raycast's down 

        //if the ground has "Paper" tag
        if (isGrounded && hitinfo.collider.CompareTag("Paper"))
        {
            if (groundedToggle) // one tick toggle
            {
                groundedToggle = false;// stops update from parenting the plaform every frame
                transform.parent = hitinfo.collider.transform;// makes the player a child of the platform
            }
        }
        if (!isGrounded)
        {
            transform.parent = null;// unparents everything from the player
            groundedToggle = true;// allows update to call the Toggle() function again
        }
    }
}