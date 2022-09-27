using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : State
{
    float visDist = 30f;

    public Idle(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = STATE.IDLE;
    }

    public override void Enter()
    {
        anim.SetTrigger("isIdle");
        base.Enter();
    }

    public override void Update()
    {
        if(isGrounded)
        {
            Debug.Log("here");
            var temp = Random.Range(0, 10);
            rb.AddForce(new Vector3(temp, 3, temp),ForceMode.Impulse);
            Debug.Log(temp);
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

