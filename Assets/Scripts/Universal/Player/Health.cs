using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;

    private void Start()
    {

    }
    private void OnEnable()
    {
        GameEvents.DamagePlayer += DamagePlayer;
        GameEvents.PlayerDeath += PlayerDeath;
    }

    private void OnDisable()
    {
        GameEvents.DamagePlayer -= DamagePlayer;
        GameEvents.PlayerDeath -= PlayerDeath;
    }
    public void DamagePlayer(int damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            GameEvents.PlayerDeath?.Invoke();
        }
        else
        {
            GameEvents.CurrentHealth?.Invoke(health);
        }
    }
    public void PlayerDeath()
    {
        gameObject.SetActive(false);
    }

}
