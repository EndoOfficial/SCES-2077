using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PillAttackState : PillState
{
    public PillAttackState(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
    : base(_npc, _agent, _anim, _player)
    {
        name = STATE.ATTACK;
    }
    public override void Enter()
    {
        Debug.Log("PILL ATTACK STATE ENTERED");
        base.Enter();
    }
    public override void Update()
    {

    }
    public override void Exit()
    {
        base.Exit();
    }
}
