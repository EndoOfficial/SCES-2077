using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireWisp : FireState
{
    DetectWheat wheat;
    public FireWisp(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = FIRESTATE.Wisp;
    }

    public override void Enter()
    {
        Debug.Log("FireWisp");
        wheat = npc.GetComponent<DetectWheat>();
        rb = npc.GetComponent<Rigidbody>();
        wheat.FindWheat();
        base.Enter();
    }

    public override void Update()
    {
        agent.destination = wheat.closestWheatPatch;
        if (wheat.inWheat)
        {
            nextState = new FireBall(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}