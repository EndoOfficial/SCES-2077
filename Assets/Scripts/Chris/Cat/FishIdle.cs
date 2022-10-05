using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishIdle : FishState
{
    FishAI ai;
    public FishIdle(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = FISHSTATE.IDLE;
    }

    public override void Enter()
    {
        Debug.Log("FISH IDLE ENTERED");
        anim.SetTrigger("isIdle");
        rb = npc.GetComponent<Rigidbody>();
        ai = npc.GetComponent<FishAI>();
        base.Enter();
    }

    public override void Update()
    {
        if (ai.detected)
        {
            nextState = new FishPursuit(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle");
        base.Exit();
    }
}