using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpreadSheetState2 : SpreadSheetState
{
    private CellSpawner CellSpawner;
    private Enemy SpreadSheet;
    public SpreadSheetState2(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {

    }
    public override void Enter()
    {
        Debug.Log("SecondState");
        CellSpawner = npc.GetComponent<CellSpawner>();
        CellSpawner.SpawnLimit = 20;
        CellSpawner.SpawnDealChance = 38;
        CellSpawner.State2 = true;
        SpreadSheet = npc.GetComponent<Enemy>();
        base.Enter();
    }
    public override void Update()
    {
        if (SpreadSheet.health <= 50)
        {
            nextState = new SpreadSheetState3(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        //anim.ResetTrigger("Rage1");
        base.Exit();
    }
}
