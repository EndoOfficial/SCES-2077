using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SyringeAI : MonoBehaviour
{
    public GameObject Player;
    Animator anim;
    SyringeState CurrentState;
    public bool Detected;
    public GameObject Child;
    public bool grounded;
    public bool Jumping;
    public bool JumpToRoof;
    public bool Turretable;
    SyringeJump TurretBool;

    // Start is called before the first frame update
    void Start()
    {
        CurrentState = new SyringeIdle(this.gameObject, anim, Player);

        TurretBool = GetComponent<SyringeJump>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState = CurrentState.Process();

        grounded = Child.GetComponent<GroundCheck>().Grounded;

        Debug.Log(CurrentState);
        //if (grounded)
        //{
        //    if (Random.Range(0, 100) < 100 && !Turretable)
        //    {
        //        Turretable = true;
        //        TurretBool.Turret = true;
        //        JumpToRoof = true;
        //    }

        //}
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Roof" && grounded)
        {
            if (Random.Range(0, 100) < 100 && !Turretable)
            {
                Turretable = true;
                TurretBool.Turret = true;
                JumpToRoof = true;
            }

        }        

    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.tag == "Roof")
        {
            Debug.Log("Exit");
            StartCoroutine(Stand());
            
        }
    }

    public IEnumerator Stand()
    {
        yield return new WaitForSeconds(0.75f);
        Turretable = false;
        TurretBool.Turret = false;
        JumpToRoof = false;
        TurretBool.Jumping = false;
        
        //yield return null;
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