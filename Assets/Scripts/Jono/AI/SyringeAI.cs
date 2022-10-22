using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SyringeAI : MonoBehaviour
{
    public GameObject Player;
    SyringeState CurrentState;
    public bool Detected;
    public GameObject Child;    
    public bool Jumping;
    public bool JumpToRoof;
    SyringeJump TurretBool;
    Animator anim;
    public BoxCollider GroundCheck;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();

        CurrentState = new SyringeIdle(this.gameObject, Player, anim);

        TurretBool = GetComponent<SyringeJump>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState = CurrentState.Process();

        //grounded = Child.GetComponent<GroundCheck>().Grounded;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Roof")
        {
            if(Random.Range(0, 100) < 25)
            {
                TurretBool.Turret = true;
                JumpToRoof = true;
            }
            
        }
        
    }
    



    private void OnEnable()
    {
        GameEvents.DetectPlayer += DetectPlayer;
    }

    private void OnDisable()
    {
        GameEvents.DetectPlayer -= DetectPlayer;
    }

    private void DetectPlayer(bool detect)
    {
        if(detect) { Detected = true; }
        else { Detected = false; }
    }
}


//void OnTriggerEnter(Collider other)
//{
//    if (other.tag == "Roof" && CanJumpToRoof)
//    {


//        if (Random.Range(0, 100) < 8)
//        {
//            //ChosenAttach = AttachmentPoints[Random.Range(0, AttachmentPoints.Count)];
//            SpringForce = 800f;
//            Jumping = true;
//            transform.rotation = Quaternion.Euler(Random.Range(-50, 50), 0, Random.Range(-50, 50));
//            MyRB.AddForce(transform.up * SpringForce);
//            CanJumpToRoof = false;



//        }

//    }
//}

//void OnTriggerExit(Collider other)
//{
//    if (other.tag == "Roof" && IsGrounded)
//    {
//        Jumping = false;
//    }
//}