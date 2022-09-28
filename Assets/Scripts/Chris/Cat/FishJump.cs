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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _collider = this.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            grounded = true;
            StartCoroutine(Wait());
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
            jumpDirection = new Vector3(UnityEngine.Random.Range(-5, 5), 4, UnityEngine.Random.Range(-5, 5));
            _collider.enabled = false;
            yield return new WaitForSecondsRealtime(waitTime);
            grounded = false;
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(jumpDirection, ForceMode.Impulse);
            rb.AddTorque(new Vector3(jumpDirection.x, 0, 0), ForceMode.Impulse);
            _collider.enabled = true;
        }
    }
}
