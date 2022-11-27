using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpreadSheetState3 : SpreadSheetState
{
    private CellSpawner CellSpawner;
    private Enemy SpreadSheet;
    public SpreadSheetState3(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {

    }
    public override void Enter()
    {
        CellSpawner = npc.GetComponent<CellSpawner>();

        CellSpawner.SpawnLimit = 30;
        CellSpawner.SpawnDealChance = 25;
        CellSpawner.State2 = false;
        CellSpawner.State3 = true;

        // ensures more cells spawn and there is a lesser
        // chance of spawning cells to deal damage to the boss
        // as well as colour setting in the cells
        SpreadSheet = npc.GetComponent<Enemy>();
        base.Enter();
    }
    public override void Update()
    {
        if (SpreadSheet.health <= 0)
        {
            GameEvents.LevelWin?.Invoke(); 
            // currently because I have no death animation set up
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        Object.Destroy(npc);
        base.Exit();
    }
}
