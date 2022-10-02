using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pursuit : State
{
    public Pursuit(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = STATE.PURSUIT;
    }

    public override void Enter()
    {
        rb = npc.GetComponent<Rigidbody>();
        base.Enter();
    }

    public override void Update()
    {
        Debug.Log("pursuit");
        base.Update();
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle");
        base.Exit();
    }
}
