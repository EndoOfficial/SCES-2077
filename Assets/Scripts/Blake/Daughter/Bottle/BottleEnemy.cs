using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleEnemy : Enemy
{
    public GameObject pill;
    protected override void Die()
    {
        Instantiate(pill);
        base.Die();
    }
}
