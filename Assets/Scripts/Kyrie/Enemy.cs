using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health;
    public float maxHealth;
    protected Animator anim;

    public GameObject Canvas;
    public Slider slider;

    public bool IsDead;

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
        if (this.gameObject == target)
        {
            
            if (health <= 0f) // if true, Die
            {
                IsDead = true;
                if (IsDead)
                {
                    anim.SetTrigger("Death");
                    //Add Die function as event in death animator
                }

            }
            else
            {
                if (!IsDead)
                {
                    anim.SetTrigger("Damage");
                    health -= damage;
                }
                
            }
        }
    }

    protected virtual void Die()
    {
        if (slider != null) slider.enabled = false;
        Destroy(gameObject);
    }

    private void Update()
    {
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