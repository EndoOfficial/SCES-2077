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
    private Animator anim;
    private float temp;

    private void Start()
    {
        //get components
        rb = GetComponent<Rigidbody>();
        aoe = GetComponent<AOE>();
        anim = GetComponent<Animator>();
        temp = waitTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            grounded = true;
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
            waitTime = temp * UnityEngine.Random.Range(0.8f, 1.2f);
            yield return new WaitForSecondsRealtime(waitTime);
            grounded = false;

            rb.velocity = new Vector3(0, 0, 0);//reset velocity
            //clamp velocity
            jumpDirection.x = Mathf.Clamp(jumpDirection.x, -5f, 5f);
            jumpDirection.y = 6f;
            jumpDirection.z = Mathf.Clamp(jumpDirection.z, -5f, 5f);

            anim.SetTrigger("Jump");
            rb.AddForce(jumpDirection, ForceMode.Impulse);//add force and torque
        }
    }
}