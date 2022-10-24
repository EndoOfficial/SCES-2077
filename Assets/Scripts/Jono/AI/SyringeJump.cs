using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeJump : MonoBehaviour
{
    public List<GameObject> AttachmentPoints = new List<GameObject>();
    private Rigidbody rb;
    public float SpringForce;
    public float ForwardSpeed;
    public float tempSpeed;
    public bool Jumping; //SyringeJump Jump;
    public bool Turret;
    bool CanJumpToRoof;
    public bool IsGrounded;
    public bool groundToggle;
    private bool rotationToggle = false;
    private GameObject Arm;
    public Animator Anim;
    public Quaternion JumpRotation;
    [SerializeField, Range(0, 45)]
    public float jumpSpread;
    private GameObject player;
    public float stopDist;
    private Vector3 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        Anim = GetComponent<Animator>();
        tempSpeed = ForwardSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //IsGrounded = Child.GetComponent<GroundCheck>().Grounded;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
        {
            if (hit.collider.CompareTag("Ground") && !groundToggle)
            {
                groundToggle = true;
                Debug.Log("Grounded");
            }
        }
        else
        {
            groundToggle = false;
        }
        Debug.DrawRay(transform.position, Vector3.down * 1f, Color.green);
        if (!rotationToggle)
        {
            playerDirection = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z);
            if (playerDirection.magnitude > stopDist)
            {
                ForwardSpeed = tempSpeed;
            }
            else
            {
                ForwardSpeed = -tempSpeed;
            }
        }
        if (rotationToggle)
        {
            transform.rotation = new Quaternion(rb.velocity.x, 0, rb.velocity.z, 1);
        }
        //Debug.Log(transform.position.magnitude - player.transform.position.magnitude);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Arm") && !CanJumpToRoof)
        {
            transform.SetParent(collision.gameObject.transform);
            rb.isKinematic = true;
            rb.useGravity = false;
            CanJumpToRoof = false;
            Debug.Log("Doink");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Arm"))
        {
            if (groundToggle)
            {
                if (Random.Range(0, 100) < 100)
                {
                    Arm = other.gameObject;
                    IsTurret();
                    Debug.Log("Trigger");
                }
            }
        }
    }

    public void IsJumping()
    {
        bool toggle = false;
        if (!groundToggle && !toggle)
        {
            //Makes boy moves forward.
            Anim.Play("Run");
            toggle = true;
            rb.AddForce(transform.forward * ForwardSpeed);
        }
        else
        {
            // makes boy jump
            //Anim.SetTrigger("Jump");
            Anim.SetTrigger("Grounded");
            toggle = false;                        
            rb.AddForce(transform.up * SpringForce, ForceMode.Impulse);
            IsGrounded = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Debug.Log("Jump");


        }
    }

    public void IsTurret()
    {

        if (!Jumping)
        {
            var ArmDir = Arm.transform.position - transform.position;
            rb.AddForce(ArmDir * SpringForce);
            groundToggle = false;
            rotationToggle = true;
            //SpringForce = SpringForce * 5;
            //var temp = transform.position;
            //temp.x += Random.Range(-jumpSpread, jumpSpread);
            //temp.z += Random.Range(-jumpSpread, jumpSpread);
            //temp = temp.normalized;
            //JumpRotation = Quaternion.Euler(temp.x, 0, temp.z);
            //transform.rotation = JumpRotation;
            //Jumping = true;
            //Debug.Log("Turret");
            //Debug.Log(temp.x);
            //Debug.Log(temp.z);
            //MyRB.AddForce(transform.up * SpringForce);
        }
        //ChosenAttach = AttachmentPoints[Random.Range(0, AttachmentPoints.Count)];

        
        
        //CanJumpToRoof = false;
    }
}