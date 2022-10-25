using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillMovement : MonoBehaviour
{
    public float speed;
    private Transform player;
    public Vector3 lobDirection;
    public Rigidbody rb;
    public Vector3 direction;
    public bool grounded = false;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("RunForwards");
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();

        lobDirection = player.position - transform.position;
        rb.AddForce(new Vector3(lobDirection.x * 0.4f, 5, lobDirection.z * 0.4f), ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) // if Ground tag
        {
            grounded = true;
        }
    }
    void Update()
    {
        if (grounded)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
