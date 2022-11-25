using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public int xpPoints;
    protected Animator anim;

    public GameObject Canvas;
    public Slider slider;

    public bool canDie = true;
    private void OnEnable()
    {
        GameEvents.DamageEnemy += TakeDamage;
    }
    private void OnDisable()
    {
        GameEvents.DamageEnemy -= TakeDamage;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        health = maxHealth;
        if (Canvas != null)
        {
            slider = Canvas.transform.Find("Slider").GetComponent<Slider>();
            slider.value = CalculateHealth();
        }
    }

    protected virtual void TakeDamage(int damage, GameObject target)
    {
        if (gameObject == target)
        {
            //GameEvents.OnCorporateplayAudio?.Invoke(audioCycle.GetNextAudioSource(), AudioManager.CorporateClipTags.CokeHurt);
            anim.SetTrigger("Damage");
            health -= damage;
        }
    }
    protected virtual void Die()
    {
        if (slider != null) slider.enabled = false;
        GameEvents.GetXP?.Invoke(xpPoints);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (health <= 0f) // if true, Die
        {
            if (canDie)
            {
                //Toggle canDie
                anim.SetTrigger("Death");
                canDie = false;
                //Add Die function as event in death animator
            }
        }
        if (slider != null)
        {
            // update health slider
            slider.value = CalculateHealth();
        }
    }
    float CalculateHealth()
    {
        return health / maxHealth;
    }
}