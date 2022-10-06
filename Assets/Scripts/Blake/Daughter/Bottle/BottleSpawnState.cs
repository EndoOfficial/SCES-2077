using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BottleSpawnState : PillState
{
    SpawnPills StartSpawn;
    private bool Started = false;
    public BottleSpawnState(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = PILLSTATE.SPAWN;
    }
    public override void Enter()
    {
        base.Enter();
        StartSpawn = npc.GetComponent<SpawnPills>();
    }
    public override void Update()
    {
        if (!Started)
        {
            Started = true;
            StartSpawn.StartSpawn();
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}