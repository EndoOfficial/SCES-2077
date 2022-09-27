using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : State
{
    float visDist = 30f;
    private AI ai;

    private float waitTimeRemaining;
    private IdleTimer idleTimer;

    public Idle(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = STATE.IDLE;
        idleTimer = _npc.GetComponent<IdleTimer>();
    }

    public override void Enter()
    {
        ResetWaitTime();

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
            waitTimeRemaining -= Time.deltaTime;
            if (waitTimeRemaining <= 0)
            {
                ResetWaitTime();
                rb.velocity = new Vector3(0, 0, 0);
                rb.AddForce(new Vector3(Random.Range(-5, 5), 4, Random.Range(-5, 5)), ForceMode.Impulse);
                ai._grounded = false;
            }
        }

        if (player.position.magnitude - npc.transform.position.magnitude <= visDist)
        {
            nextState = new Persuit(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }
    private void ResetWaitTime()
    {
        if (idleTimer == null)
            return;

        waitTimeRemaining = idleTimer.RandomWaitTime;
    }
    public override void Exit()
    {
        anim.ResetTrigger("isIdle");
        base.Exit();
    }
}