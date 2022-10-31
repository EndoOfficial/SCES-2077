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
    public bool particleActivated;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyCoke"))
        {
            particleActivated = true;
            cokeParticle.gameObject.SetActive(true);
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

    
