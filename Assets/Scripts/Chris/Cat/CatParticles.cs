using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatParticles : MonoBehaviour
{
    private ParticleSystem particles;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            particles.Play();
        }   
    }
}
