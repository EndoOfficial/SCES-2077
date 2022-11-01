using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireBall : FireState
{
    public FireBall(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = FIRESTATE.Fire;
    }

    public override void Enter()
    {
        wheat = npc.GetComponent<DetectWheat>();
        rb = npc.GetComponent<Rigidbody>();
        spawner = npc.GetComponent<WispSpawner>();
        timer = npc.GetComponent<FireTimer>();

        anim.SetTrigger("BecomeFireBall");
        spawner.stopSpawn();
        npc.transform.LeanScale(new Vector3(2, 2, 2), 1);
        agent.speed = 3.5f;
        timer.StartTimer();
        base.Enter();
    }

    public override void Update()
    {
        if (Vector3.Distance(npc.transform.position, player.transform.position) >= 10)
        {
            agent.isStopped = false;
            agent.destination = player.transform.position;
        }
        else
        {
            agent.isStopped = true;
            npc.transform.RotateAround(player.transform.position, Vector3.up, 0.1f);
        }

        if(timer.timeDone)
        {
            nextState = new FireNado(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("BecomeFireBall");
        base.Exit();
    }
}