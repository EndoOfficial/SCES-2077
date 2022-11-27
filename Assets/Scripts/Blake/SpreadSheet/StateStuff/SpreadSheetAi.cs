using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpreadSheetAi : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public GameObject player;
    State currentState;

    void Start()
    {
        currentState = new SpreadSheetState(gameObject, agent, anim, player);
    }
    void Update()
    {
        currentState = currentState.Process();
    }
}
