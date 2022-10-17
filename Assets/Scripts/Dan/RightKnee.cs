using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RightKnee : GruntState
{
    Grunts Grunt;
    HeadShot head;
    public RightKnee(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = GRUNTSTATE.RIGHTKNEE;
    }

    public override void Enter()
    {
        anim.SetTrigger("RightKnee");
        rb = npc.GetComponent<Rigidbody>();
        Grunt = npc.GetComponent<Grunts>();
        head = npc.GetComponent<HeadShot>();
       
        Grunt.speedEffect = 0.5f;
        Grunt.damage = 5;
        Debug.Log("RightKnee");
        base.Enter();
    }

    public override void Update()
    {
        if (head.left == false && head.right == false)
        {
            nextState = new Normal(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }

        if (head.head)
        {
            Debug.Log("EnterTwoknee");

            nextState = new TwoKnee(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("RightKnee");
        base.Exit();
    }
}

