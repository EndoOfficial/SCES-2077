using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireState : State
{
    public FIRESTATE name;

    public enum FIRESTATE
    {
        IDLE, PURSUIT, ATTACK
    }

    public FireState(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {

    }

    public override void Enter() { stage = EVENT.UPDATE; }
    public override void Update() { stage = EVENT.UPDATE; }
    public override void Exit() { stage = EVENT.EXIT; }
}
