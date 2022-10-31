using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireBall : FireState
{
    private Vector3 pos;
    public FireBall(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = FIRESTATE.Fire;
    }

    public override void Enter()
    {
        Debug.Log("FireBall");
        rb = npc.GetComponent<Rigidbody>();
        base.Enter();
    }

    public override void Update()
    {
        if ((npc.transform.position - player.transform.position).magnitude >= 10)
        {
            agent.destination = player.transform.position;
        }
        else
        {
            npc.transform.Translate(npc.transform.right);
        }

        if(timer.time >= timer.changeTime)
        {
            nextState = new FireNado(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}