using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pursuit : State
{
    AI ai;
    public Pursuit(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = STATE.PURSUIT;
    }

    public override void Enter()
    {
        rb = npc.GetComponent<Rigidbody>();
        ai = npc.GetComponent<AI>();
        base.Enter();
    }

    public override void Update()
    {
        Debug.Log("pursuit");
        if (ai.detected == true)
        {
            nextState = new Idle(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
        base.Update();
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle");
        base.Exit();
    }
}
