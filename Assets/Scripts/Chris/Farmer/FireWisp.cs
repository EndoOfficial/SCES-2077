using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireWisp : FireState
{
    public FireWisp(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = FIRESTATE.IDLE;
    }

    public override void Enter()
    {
        anim.SetTrigger("isIdle");
        rb = npc.GetComponent<Rigidbody>();
        base.Enter();
    }

    public override void Update()
    {
        agent.destination = player.transform.position - npc.transform.position;
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle");
        base.Exit();
    }
}