using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeTurret : SyringeState
{
    SyringeAI AI;
    SyringeJump Turret;
    Animator anim;
    public SyringeTurret(GameObject _npc, GameObject _player, Animator _anim)
        : base(_npc, _player, _anim)
    {
        name = SyringeSTATE.IDLE;
    }
    public override void Enter()
    {
        Debug.Log("Syringe Turret");
        
        rb = NPC.GetComponent<Rigidbody>();
        AI = NPC.GetComponent<SyringeAI>();
        anim = NPC.GetComponent<Animator>();
        Turret = NPC.GetComponent<SyringeJump>();
        
        base.Enter();
    }

    public override void Update()
    {
        if (Turret.IsGrounded)
        {
            Turret.IsTurret();
        }
    }

    public override void Exit()
    {
        Debug.Log("Syringe left Turret");
        base.Exit();
    }
}
