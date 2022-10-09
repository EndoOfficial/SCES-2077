using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 200;
    public void TakeDamage(float damage)
    {
        health -= damage;
        GameEvents.Health?.Invoke(health);
        if (health <= 0f)
        {
            GameEvents.PlayerDeath?.Invoke();
        }
    }
}
