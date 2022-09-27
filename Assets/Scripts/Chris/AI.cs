using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public Transform player;
    State currentState;
    public bool _grounded;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        currentState = new Idle(this.gameObject, agent, anim, player);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
    }

    private void OnEnable()
    {
        GameEvents.isGrounded += isGrounded;
    }
    private void OnDisable()
    {
        
        GameEvents.isGrounded -= isGrounded;
    }

    private void isGrounded(bool grounded)
    {
        _grounded = true;
    }
}
