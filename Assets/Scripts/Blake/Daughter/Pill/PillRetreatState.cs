using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PillRetreatState : PillState
{
    RetreatTimer Timer;
    PillMovement Running;
    public PillRetreatState(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
    : base(_npc, _agent, _anim, _player)
    {
        name = PILLSTATE.RETREAT;
    }
    public override void Enter()
    {
        base.Enter();
        Timer = npc.GetComponent<RetreatTimer>();
        Timer.Timer();
        Running = npc.GetComponent<PillMovement>();
        Running.speed = -6f;
    }
    public override void Update()
    {
        if (Timer.TimesUp)
        {
            nextState = new PillAttackState(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}