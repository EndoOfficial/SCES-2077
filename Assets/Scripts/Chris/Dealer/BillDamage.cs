using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillDamage : MonoBehaviour
{
    private int damage = 5;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Destroys the object when it hits you
            enemy.TakeDamage(1000, gameObject);
            // damages the player
            GameEvents.DamagePlayer?.Invoke(damage);
            Destroy(gameObject);
        }
    }
}
