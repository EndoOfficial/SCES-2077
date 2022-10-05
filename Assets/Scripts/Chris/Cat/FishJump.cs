using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishJump : MonoBehaviour
{
    public float waitTime;
    private Rigidbody rb;
    public bool grounded;
    private BoxCollider _collider;
    public Vector3 jumpDirection;
    public FishAI ai;

    private void Start()
    {
        //get components
        rb = GetComponent<Rigidbody>();
        _collider = this.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) // if Ground tag
        {
            grounded = true;
            jumpDirection = new Vector3(UnityEngine.Random.Range(-5, 5), 0, UnityEngine.Random.Range(-5, 5));// set jump direction randomly
            StartCoroutine(Wait()); // start co-routine
            GameEvents.AOE?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        grounded = false;
    }

    private IEnumerator Wait()
    {
        if (grounded)
        {
            _collider.enabled = false;//disable trigger collider
            yield return new WaitForSecondsRealtime(waitTime);
            grounded = false;
            rb.velocity = new Vector3(0, 0, 0);//reset velocity
            jumpDirection.x = Mathf.Clamp(jumpDirection.x, -5f, 5f);
            jumpDirection.y = 0f;
            jumpDirection.z = Mathf.Clamp(jumpDirection.z, -5f, 5f);
            rb.AddForce(jumpDirection, ForceMode.Impulse);//add force and torque
            rb.AddForce(new Vector3(0, 6, 0), ForceMode.Impulse);
            rb.AddTorque(new Vector3(jumpDirection.x, 0, 0), ForceMode.Impulse);
            _collider.enabled = true;//re-enable the trigger collider
        }
    }
}