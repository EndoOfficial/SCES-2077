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
        GameEvents.DamagePlayer -= DamagePlayer;
    }
    public void DamagePlayer(int damage)
    {
        // reduce health then update it
        health -= damage;
        if (health <= 0f)
        {
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
<<<<<<< Updated upstream
        // display a death screen
=======
        GameEvents.OnGameOver?.Invoke(true);
        // disables the player because destroying is bad
        //gameObject.SetActive(false);
>>>>>>> Stashed changes
    }

}
