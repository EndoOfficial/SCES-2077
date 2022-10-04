using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PillAttackState : PillState
{
    public Vector3 direction;
    public PillAttackState(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
    : base(_npc, _agent, _anim, _player)
    {
        name = PILLSTATE.ATTACK;
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
    direction = player.transform.position - npc.transform.position;
    }
    public override void Exit()
    {
        base.Exit();
    }
}
