using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealerEnemy : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;

    public GameObject healthBarUi;
    public Slider slider;
    public GameObject baby;
    public GameObject[] spawners;

    private void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("here");
        for(int i = 0; i < spawners.Length; i++)
        {
            Instantiate(baby, spawners[i].transform);
        }
    }

    private void Update()
    {
        slider.value = CalculateHealth();

        if (health < maxHealth)
        {
            healthBarUi.SetActive(true);
        }
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }

}