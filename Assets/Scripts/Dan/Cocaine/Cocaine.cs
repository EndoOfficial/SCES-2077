using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cocaine : MonoBehaviour
{

    public LayerMask Player;
    public float radius;
    public int damage;
    public bool hit;
    public ParticleSystem cokeParticle;
    public bool particleActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            particleActivated = true;
            cokeParticle.Play();
        }
        if (other.gameObject.CompareTag("Player") && particleActivated)
        {
            if (Physics.CheckSphere(transform.position, radius, Player))
            {
                if (!hit)
                {
                    hit = true;
                    GameEvents.DamagePlayer?.Invoke(damage);
                }
            }
            else
            {
                hit = false;
            }
        }
    }
}

    
