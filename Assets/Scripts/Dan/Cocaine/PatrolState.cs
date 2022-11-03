using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : CokeEnemyState
{
    Mrcoke2 MrCocaine;
    public PatrolState(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = COKEENEMYSTATE.PATROL;
    }
    public override void Enter()
    {
        //anim.SetTrigger("Patrol");
        rb = npc.GetComponent<Rigidbody>();
        MrCocaine = npc.GetComponent<Mrcoke2>();
        base.Enter();
    }
    public override void Update()
    {

        //if (xyz)
        //{
        //    nextState = new MEELEE(npc, agent, anim, player);
        //    stage = EVENT.EXIT;
        //}

        //if (xyz)
        //{
        //    Puff Stuff
        //}
    }
}