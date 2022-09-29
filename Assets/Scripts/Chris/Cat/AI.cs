using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public GameObject player;
    State currentState;
    public bool detected;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        currentState = new Idle(gameObject, agent, anim, player);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
    }

    private void OnEnable()
    {
        GameEvents.DetectPlayer += DetectPlayer;
    }

    private void OnDisable()
    {
        GameEvents.DetectPlayer -= DetectPlayer;
    }

    private void DetectPlayer(bool detect)
    {
        if (detect) { detected = true; }
        else { detected = false; }
    }
}
