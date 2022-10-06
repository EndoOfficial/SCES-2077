using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 200;

    public void TakeDamage(float amount)
    {
        
        health -= amount;
        GameEvents.Health?.Invoke(health);
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
