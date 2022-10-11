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
        GameEvents.DamagePlayer += TakeDamage;
        GameEvents.PlayerDeath += Die;
    }

    private void OnDisable()
    {
        GameEvents.DamagePlayer -= TakeDamage;
        GameEvents.PlayerDeath -= Die;
    }
    public void TakeDamage(int damage)
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
    public void Die()
    {
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<CapsuleCollider>().enabled = false;
        this.GetComponent<MeshRenderer>().enabled = false;
        //Player.GetComponent<PlayerController>().enabled = false; // Uncomment once new CharacterController exists
    }

}
