using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStick : MonoBehaviour
{

    public Transform groundCheck;
    public float groundDistance = 0.8f;
    public LayerMask groundMask;
    public bool isGrounded;

    private void Update()
    {
        isGrounded = Physics.Raycast(groundCheck.position, Vector3.down, out RaycastHit hitinfo, groundDistance, groundMask);

        if (isGrounded && hitinfo.collider.CompareTag("Paper"))
        {
            transform.parent = hitinfo.collider.transform;
            Debug.Log("You are standing on Paper");
        }
    }
}
