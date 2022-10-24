using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringePursuit : SyringeState
{
    SyringeAI ai;
    SyringeJump Jump;
    bool JumpToRoof;
    
    public SyringePursuit(GameObject _npc, Animator _anim, GameObject _player)
        : base(_npc, _player, _anim)
    {
        name = SyringeSTATE.PURSUIT;
    }

    public override void Enter()
    {
        Debug.Log("InPursuit");
        rb = NPC.GetComponent<Rigidbody>();
        ai = NPC.GetComponent<SyringeAI>();
        Jump = NPC.GetComponent<SyringeJump>();
        base.Enter();
    }

    public override void Update()
    {
        Jump.IsJumping();

        if (JumpToRoof)
        {
            nextState = new SyringeTurret(NPC, player, Anim);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        //Anim.ResetTrigger("isIdle");
        base.Exit();
    }
}