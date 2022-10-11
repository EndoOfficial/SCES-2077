using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;

    public GameObject healthBarUi;
    private Slider slider;

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
        health = maxHealth;
        if (healthBarUi != null)
        {
            slider = healthBarUi.transform.Find("Slider").GetComponent<Slider>();   
            slider.value = CalculateHealth();
        }
    }

    public void TakeDamage(int damage, Enemy target)
    {
        if(this.gameObject == target)
        {
            health = target.health -= damage;
            if (health <= 0f)
            {
                Die();
            }
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (slider != null)
        {
            slider.value = CalculateHealth();

            if (health < maxHealth)
            {
                healthBarUi.SetActive(true);
            }
        }
        
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }

}