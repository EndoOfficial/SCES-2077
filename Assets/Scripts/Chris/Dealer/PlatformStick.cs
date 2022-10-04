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
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, out RaycastHit hitinfo, groundDistance, groundMask);

        if(isGrounded && hitinfo.collider.CompareTag("Paper"))
        {
            if (groundedToggle)
            {
                Toggle(hitinfo);
            }
        }
        if (!isGrounded)
        {
            groundedToggle = true;
            transform.parent = null;
        }
    }

    private void Toggle(RaycastHit hitinfo)
    {
        groundedToggle = false;
        if (isGrounded && hitinfo.collider.CompareTag("Paper"))
        {
            transform.parent = hitinfo.collider.transform;
        }
    }
}
