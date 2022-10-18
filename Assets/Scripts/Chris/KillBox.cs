using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    private int damage = 10;
    public GameObject respawnPos;
    private CharacterController chara;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("here");
            chara = other.GetComponent<CharacterController>();
            GameEvents.DamagePlayer?.Invoke(damage);
            chara.enabled = false;
            other.transform.position = respawnPos.transform.position;
            chara.enabled = true;

        }
    }
}
