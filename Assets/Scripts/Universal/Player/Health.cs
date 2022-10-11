using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        GameEvents.OnHealthChanged?.Invoke(health, maxHealth);
        if (health <= 0f)
        {
            GameEvents.PlayerDeath?.Invoke();
            
        }
    }
}
