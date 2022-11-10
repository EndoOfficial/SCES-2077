using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishIdle : FishState
{
    FishAI ai;
    FishJump jump;
    public FishIdle(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = FISHSTATE.IDLE;
    }

    public override void Enter()
    {
        rb = npc.GetComponent<Rigidbody>();
        ai = npc.GetComponent<FishAI>();
        jump = npc.GetComponent<FishJump>();
        base.Enter();
    }

    public override void Update()
    {
        jump.jumpDirection = Vector3.zero;
        if (ai.detected)// if player is detected
        {
            nextState = new FishPursuit(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}