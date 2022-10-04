using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeController : MonoBehaviour
{
    public ConfigurableJoint CFGJ;
    public Rigidbody MyRB;
    public Rigidbody MyChildRB;
    public GameObject Child;
    public float SpringForce;
    public float speed;
    private float angle;
    public bool IsGrounded;
    public bool CanJumpToRoof;

    public GameObject Target;
    public Vector3 TargetPos;
    public Vector3 ThisPos;

    // Start is called before the first frame update
    void Start()
    {
        CFGJ = GetComponentInChildren<ConfigurableJoint>();
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Child.GetComponent<GroundCheck>().Grounded == false)
        {
            MyRB.AddForce(transform.forward * 2.5f);
            MyChildRB.AddForce(transform.forward * 2.5f);
        }
        else
        {
            MyRB.AddForce(transform.up * SpringForce);
        }

        TargetPos = Target.transform.position;
        ThisPos = transform.position;
        TargetPos.x = TargetPos.x - ThisPos.x;
        TargetPos.z = TargetPos.z - ThisPos.z;
        angle = Mathf.Atan2(TargetPos.x, TargetPos.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Roof"&& CanJumpToRoof)
        {
            CanJumpToRoof = false;
            SpringForce = 400f;
            Debug.Log("Stick to Roof");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Roof" && !CanJumpToRoof)
        {
            transform.SetParent(collision.gameObject.transform);
            MyRB.isKinematic = true;
            MyRB.useGravity = false;
            Debug.Log("Doink");
        }
    }
}
