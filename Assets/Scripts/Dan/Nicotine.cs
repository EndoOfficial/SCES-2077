using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nicotine : MonoBehaviour
{
    private float rage = -5f;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collected");
            GameEvents.Nicotine?.Invoke();
            GameEvents.RageIncrease?.Invoke(rage);
            Destroy(gameObject);
        }
    }
}