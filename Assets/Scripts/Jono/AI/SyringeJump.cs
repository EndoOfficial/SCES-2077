using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeJump : MonoBehaviour
{
    public ConfigurableJoint CFGJ;
    public GameObject Target;
    public List<GameObject> AttachmentPoints = new List<GameObject>();
    public Rigidbody MyRB;
    public Rigidbody MyChildRB;
    public GameObject Child;
    public float SpringForce = 100f;
    private float angle;
    public float ForwardSpeed;
    //SyringeJump Jump;
    public bool Jumping;
    public bool Turret;
    public Vector3 ThisPos;
    public Vector3 TargetPos;
    bool CanJumpToRoof;
    bool IsGrounded;
    // Start is called before the first frame update
    void Start()
    {
        CFGJ = GetComponentInChildren<ConfigurableJoint>();
        Target = GameObject.FindGameObjectWithTag("Player");

        

        
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = Child.GetComponent<GroundCheck>().Grounded;

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Roof" && !CanJumpToRoof)
        {
            transform.SetParent(collision.gameObject.transform);
            MyRB.isKinematic = true;
            MyRB.useGravity = false;
            CanJumpToRoof = false;
            Debug.Log("Doink");

        }

    }

    public void IsJumping()
    {
        if (Child.GetComponent<GroundCheck>().Grounded == false)
        {
            MyRB.AddRelativeForce(-transform.forward * ForwardSpeed);
            MyChildRB.AddRelativeForce(-transform.forward * ForwardSpeed);
            TargetPos = Target.transform.position;
            ThisPos = transform.position;
            TargetPos.x = TargetPos.x - ThisPos.x;
            TargetPos.z = TargetPos.z - ThisPos.z;
            angle = Mathf.Atan2(TargetPos.x, TargetPos.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        }
        else
        {
            MyRB.AddForce(transform.up * SpringForce);
            MyRB.velocity = Vector3.zero;
            MyRB.angularVelocity = Vector3.zero;
            Debug.Log("Jump");


        }
    }

    public void IsTurret()
    {
        if (Turret)
        {
            if (!Jumping)
            {
                transform.rotation = Quaternion.Euler(Random.Range(-50, 50), 0, Random.Range(-50, 50));
                
            }
            //ChosenAttach = AttachmentPoints[Random.Range(0, AttachmentPoints.Count)];
            
            Jumping = true;
            SpringForce = 800;
            MyRB.AddForce(transform.up * SpringForce);
            //CanJumpToRoof = false;
        }
    }
}
