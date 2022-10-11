using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GruntState :State
{
    public GRUNTSTATE name;
    public enum GRUNTSTATE
    {
        RAGE1, RAGE2, RAGE3, RAGE4
    }

    public GruntState(GameObject _npc, UnityEngine.AI.NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {

    }

    public override void Enter() { stage = EVENT.UPDATE; }
    public override void Update() { stage = EVENT.UPDATE; }
    public override void Exit() { stage = EVENT.EXIT; }



}
