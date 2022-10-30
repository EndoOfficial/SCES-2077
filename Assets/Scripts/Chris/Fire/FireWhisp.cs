using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireWisp : FireState
{
    private Vector3 pos;
    public FireWisp(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = FIRESTATE.Whisp;
    }

    public override void Enter()
    {
        anim.SetTrigger("isIdle");
        rb = npc.GetComponent<Rigidbody>();
        base.Enter();
    }

    public override void Update()
    {
        pos = (npc.transform.position - player.transform.position).normalized;
        var moveTarget = npc.transform.position + (pos * 1);
        agent.destination = moveTarget;
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle");
        base.Exit();
    }
}