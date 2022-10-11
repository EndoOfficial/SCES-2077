using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rage2 : CiggsState
{

    MrCiggs ciggs;

    public Rage2(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = CIGGSSTATE.RAGE2;
    }

    public override void Enter()
    {
        anim.SetTrigger("Rage1");
        rb = npc.GetComponent<Rigidbody>();
        ciggs = npc.GetComponent<MrCiggs>();
        ciggs.damage = 3;
        base.Enter();
    }

    public override void Update()
    {
        Debug.Log("isRaging");
        float randomShooting = Random.Range(0f, 1f);
        if (randomShooting >= 0.85f)
        {
            
            ciggs.Shoot();

        }
        if (ciggs.rage >= 50)
        {
            nextState = new Rage3(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
        if (ciggs.rage <= 25)
        {
            nextState = new Rage1(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }

    }

    public override void Exit()
    {
        anim.ResetTrigger("Rage1");
        base.Exit();
    }

}
