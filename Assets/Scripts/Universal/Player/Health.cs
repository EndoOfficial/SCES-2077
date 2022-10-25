using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public Text text;

    private void OnEnable()
    {
        GameEvents.DamagePlayer += DamagePlayer;
    }

    private void OnDisable()
    {
        GameEvents.DamagePlayer -= DamagePlayer;    }
    public void DamagePlayer(int damage)
    {
        //FindObjectOfType<AudioManager>().Play("Hurt");
        // reduce health then update it
        health -= damage;
        if (health <= 0f)
        {
            text.text = health.ToString();
            // stops time for a game over screen instead of destroying the player and the attached camera
            PlayerDeath();
        }
        else
        {
            // update the health text
            text.text = health.ToString();  
        }
    }
    public void PlayerDeath()
    {
        GameEvents.OnGameOver?.Invoke(true);
    }

}
