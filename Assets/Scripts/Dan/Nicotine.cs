using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nicotine : MonoBehaviour
{
    public Collider Col;
    Rigidbody rb;
    private float rage = -5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collected");
            GameEvents.Nicotine?.Invoke();
            GameEvents.RageIncrease?.Invoke(rage);
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            rb.isKinematic = true;
            Col.enabled = false;
        }
    }
}