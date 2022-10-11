using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerWin : Enemy
{
    protected override void Die()
    {
        GameEvents.LevelWin?.Invoke();
        base.Die();
    }
}
