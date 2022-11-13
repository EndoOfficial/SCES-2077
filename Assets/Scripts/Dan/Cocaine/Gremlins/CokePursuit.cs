using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CokePursuit : CokeEnemyState
{
    Mrcoke2 MrCocaine;
    PuffPatchChecker check;
    public CokePursuit(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = COKEENEMYSTATE.PURSUIT;
    }
    public override void Enter()
    {
        check = npc.GetComponent<PuffPatchChecker>();
        MrCocaine = npc.GetComponent<Mrcoke2>();
        anim.SetTrigger("Pursuit");
        rb = npc.GetComponent<Rigidbody>();
        MrCocaine.target = player;
        base.Enter();
    }
    public override void Update()
    {
        if (check.Pursue == false)
        {
            anim.SetTrigger("Patrol");
            nextState = new PatrolState(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        anim.ResetTrigger("Pursuit");
        base.Exit();
    }
}
