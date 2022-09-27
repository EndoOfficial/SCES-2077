using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Persuit : State
{
    public Persuit(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = STATE.PERSUIT;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {

        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
