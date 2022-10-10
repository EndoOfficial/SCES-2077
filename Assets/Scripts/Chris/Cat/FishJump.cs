using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishJump : MonoBehaviour
{
    public float waitTime;
    private Rigidbody rb;
    public bool grounded;
    public Vector3 jumpDirection;
    private AOE aoe;

    private void Start()
    {
        //get components
        rb = GetComponent<Rigidbody>();
        aoe = GetComponent<AOE>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            grounded = true;
            jumpDirection = new Vector3(UnityEngine.Random.Range(-5, 5), 0, UnityEngine.Random.Range(-5, 5));// set jump direction randomly
            StartCoroutine(Wait()); // start co-routine
            aoe.aoe();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }

    private IEnumerator Wait()
    {
        if (grounded)
        {
            yield return new WaitForSecondsRealtime(waitTime);
            grounded = false;

            rb.velocity = new Vector3(0, 0, 0);//reset velocity
            jumpDirection.x = Mathf.Clamp(jumpDirection.x, -5f, 5f);
            jumpDirection.y = 0f;
            jumpDirection.z = Mathf.Clamp(jumpDirection.z, -5f, 5f);

            rb.AddForce(jumpDirection, ForceMode.Impulse);//add force and torque
            rb.AddForce(new Vector3(0, 6, 0), ForceMode.Impulse);
            rb.AddTorque(new Vector3(jumpDirection.x, 0, 0), ForceMode.Impulse);
        }
    }
}