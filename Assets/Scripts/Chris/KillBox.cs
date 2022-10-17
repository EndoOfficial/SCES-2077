using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    private int damage = 10;
    public GameObject respawnPos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("here");
            GameEvents.DamagePlayer?.Invoke(damage);
            other.transform.position = respawnPos.transform.position;

        }
    }
}
