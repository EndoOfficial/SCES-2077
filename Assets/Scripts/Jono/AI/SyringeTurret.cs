using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeTurret : SyringeState
{
    SyringeAI AI;
    SyringeJump Turret;
    public SyringeTurret(GameObject _npc, GameObject _player)
        : base(_npc, _player)
    {
        name = SyringeSTATE.IDLE;
    }
    public override void Enter()
    {
        Debug.Log("Syringe Turret");
        
        rb = NPC.GetComponent<Rigidbody>();
        AI = NPC.GetComponent<SyringeAI>();
        Turret = NPC.GetComponent<SyringeJump>();
        
        base.Enter();
    }

    public override void Update()
    {
        if (AI.grounded)
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
