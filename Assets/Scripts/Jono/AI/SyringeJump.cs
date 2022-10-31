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
    public float stopDist;
    public float MainSpeed;
    public float jumpCount;
    //SyringeJump Jump;
    public bool Jumping;
    public bool Turret;
    public Vector3 ThisPos;
    public Vector3 TargetPos;
    private Vector3 playerDirection;
    public bool CanJumpToRoof;
    public bool IsGrounded;
    public bool PlayerClose;
    public Animator anim;
    SyringeAI AI;
    // Start is called before the first frame update
    void Start()
    {
        CFGJ = GetComponentInChildren<ConfigurableJoint>();
        Target = GameObject.FindGameObjectWithTag("Player");

        anim = GetComponent<Animator>();
        AI = GetComponent<SyringeAI>();
        //IsGrounded = GetComponent<GroundCheck>().Grounded;
        jumpCount = Random.Range(2, 8);

        MainSpeed = ForwardSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = Child.GetComponent<GroundCheck>().Grounded;
        //Debug.DrawRay(transform.position, -Vector3.up * 1f, Color.blue);
        //RaycastHit hit;
        //if(Physics.Raycast(transform.position, Vector3.down, out hit, 0.5f))
        //{
        //    Debug.Log(hit.collider.tag);
        //    if(hit.collider.tag == "Ground")
        //    {

        //        IsGrounded = true;
        //        //anim.SetBool("Grounded 0", true);
        //    }
        //    if(hit.collider.tag == null)
        //    {                
        //        IsGrounded = false;
        //        //anim.SetBool("Grounded 0", false);
        //    }


        //}

        

        playerDirection = new Vector3(Target.transform.position.x - transform.position.x, 0, Target.transform.position.z - transform.position.z);
        if(playerDirection.magnitude > stopDist)
        {
            PlayerClose = false;
            ForwardSpeed = MainSpeed;
        }
        else
        {
            PlayerClose = true;
            ForwardSpeed = -MainSpeed;
        }


        

        //Debug.Log(transform.position.magnitude - Target.transform.position.magnitude);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Roof" && AI.JumpToRoof)
        {
            FindObjectOfType<AudioManager>().Play("Impact");
            transform.SetParent(collision.gameObject.transform);
            MyRB.isKinematic = true;
            MyRB.useGravity = false;
            CanJumpToRoof = false;
            Debug.Log("Doink");
            anim.SetTrigger("Jump");
            anim.SetTrigger("Wall");

        }

    }

    public void IsJumping()
    {
        if (Child.GetComponent<GroundCheck>().Grounded == false)
        {
            anim.ResetTrigger("Grounded");            
            MyRB.AddRelativeForce(-transform.forward * ForwardSpeed);
            MyChildRB.AddRelativeForce(-transform.forward * ForwardSpeed);
            TargetPos = Target.transform.position;
            ThisPos = transform.position;                                           //Makes Move Forwards when not grounded
            TargetPos.x = TargetPos.x - ThisPos.x;
            TargetPos.z = TargetPos.z - ThisPos.z;
            angle = Mathf.Atan2(TargetPos.x, TargetPos.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        }
        else
        {
            anim.SetTrigger("Grounded");
            FindObjectOfType<AudioManager>().Play("Jump");
            MyRB.AddForce(transform.up * SpringForce);
            MyRB.velocity = Vector3.zero;                                         // Makes Jump Up
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
