using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrisHealth : MonoBehaviour
{
    public float health = 200;
    private void OnEnable()
    {
        GameEvents.PlayerDamage += PlayerDamage;
    }
    private void OnDisable()
    {
        GameEvents.PlayerDamage -= PlayerDamage;
    }

    public void PlayerDamage(int damage)
    {
        health -= damage;
        GameEvents.Health?.Invoke(health);
        if (health <= 0f)
        {
            GameEvents.PlayerDeath?.Invoke();
        }
    }
}
