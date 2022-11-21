using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellShot : Enemy
{
    public int Damage;
    private void Update()
    {
        Damage = GetComponent<CellDamage>().damage;
    }
    protected override void TakeDamage(int damage, GameObject target)
    {
        if (gameObject == target)
        {
            if (name == "TakeDamageCell(Clone)")
            {
                Debug.Log(Damage + " Damage taken");
                GameEvents.DamagePlayer?.Invoke(Damage);
            }
            else if(name == "DealDamageCell(Clone)")
            {
                Debug.Log(Damage + " Damage Dealt (once I get there)");
            }
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