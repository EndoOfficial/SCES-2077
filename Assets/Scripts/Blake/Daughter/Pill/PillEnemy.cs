using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillEnemy : Enemy
{
    private Animator Anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        GameEvents.BottleDeath += KillAll;
    }

    private void OnDisable()
    {
        GameEvents.BottleDeath += KillAll;
    }

    public void KillAll()
    {
        Anim.SetTrigger("Death");
    }
}
