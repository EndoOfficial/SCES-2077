using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BottleSpawnState : PillState
{
    public BottleSpawnState(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = PILLSTATE.SPAWN;
    }
    public override void Enter()
    {
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
