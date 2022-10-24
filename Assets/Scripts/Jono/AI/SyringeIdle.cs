using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;

public class SyringeIdle : SyringeState
{
    SyringeAI AI;
    public SyringeIdle (GameObject _npc, GameObject _player, Animator _anim)
        : base(_npc, _player,_anim )
    {
        name = SyringeSTATE.IDLE;
    }
    public override void Enter()
    {
        Debug.Log("Syringe IDLE");

        rb = NPC.GetComponent<Rigidbody>();
        AI = NPC.GetComponent<SyringeAI>();
        Anim = NPC.GetComponent<Animator>();
        base.Enter();
    }

    public override void Update()
    {
        if (AI.Detected)
        {
            nextState = new SyringePursuit(NPC, Anim, player);
            stage = EVENT.EXIT;
        }     
    }

    public override void Exit()
    {
        Debug.Log("Syringe left IDLE");
        base.Exit();
    }


}