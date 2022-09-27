using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : State
{
    float visDist = 30f;
    private AI ai;
    public Idle(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = STATE.IDLE;
    }

    public override void Enter()
    {
        ai = npc.GetComponent<AI>();
        anim.SetTrigger("isIdle");
        rb = npc.GetComponent<Rigidbody>();
        base.Enter();
    }

    public float i = 0;
    public override void Update()
    {
        if (ai._grounded)
        {
            while(i < 100)
            {
                i++;
                
            }
            if (i == 100)
                {
                    i = 0;
                    rb.velocity = new Vector3(0, 0, 0);
                    rb.AddForce(new Vector3(Random.Range(-5, 5), 3, Random.Range(-5, 5)), ForceMode.Impulse);
                    ai._grounded = false;
                    GameEvents.AOE?.Invoke();
                }
        }

        //if (player.position.magnitude - npc.transform.position.magnitude <= visDist)
        //{
        //    nextState = new Persuit(npc, agent, anim, player);
        //    stage = EVENT.EXIT;
        //}
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle");
        base.Exit();
    }
}


