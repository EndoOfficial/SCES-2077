using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PillAttackState : PillState
{
    PillMovement Running;
    HitPlayer Hit;
    public PillAttackState(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
    : base(_npc, _agent, _anim, _player)
    {
        name = PILLSTATE.ATTACK;
    }
    public override void Enter()
    {
        anim.SetTrigger("RunForwards");
        Hit = npc.GetComponent<HitPlayer>();
        Running = npc.GetComponent<PillMovement>();
        Running.speed = 2f;
        base.Enter();
    }
    public override void Update()
    {
        if (Hit.hit)
        {
            anim.SetTrigger("Attack");
            nextState = new PillRetreatState(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        anim.ResetTrigger("RunForwards");
        base.Exit();
    }
}
