using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public Text text;
    private AudioCycle audioCycle;

    private void OnEnable()
    {
        GameEvents.DamagePlayer += DamagePlayer;
    }

    private void OnDisable()
    {
        GameEvents.DamagePlayer -= DamagePlayer;    
    }

    private void Start()
    {
        audioCycle = GetComponent<AudioCycle>();
    }

    public void DamagePlayer(int damage)
    {
        //FindObjectOfType<AudioManager>().Play("Hurt");
        // reduce health then update it
        health -= damage;
        GameEvents.OnUniversalplayAudio?.Invoke(audioCycle.GetNextAudioSource(), AudioManager.UniversalClipTags.PlayerHurt);
        if (health <= 0f)
        {
            text.text = health.ToString();
            //GameObject.Find("Player").SendMessage("Finnish");
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
