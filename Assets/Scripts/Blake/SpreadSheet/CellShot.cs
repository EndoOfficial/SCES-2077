using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellShot : Enemy
{
    protected override void TakeDamage(int damage, GameObject target)
    {
        if (gameObject == target)
        {
            GameEvents.CellsShot?.Invoke();
        }
    }
    private void OnEnable()
    {
        GameEvents.CellsShot += CellDie;
        GameEvents.DamageEnemy += TakeDamage; // required to be shot
    }

    private void OnDisable()
    {
        GameEvents.CellsShot -= CellDie;
        GameEvents.DamageEnemy -= TakeDamage; // required to be shot
    }
    void CellDie()
    {
        transform.parent.tag = ("SpawnLocation");
        // allows cells to spawn in this location

        Destroy(gameObject);
    }
}