using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunButforall : MonoBehaviour
{
    public int damage = 10; //Damge of bullet. Doesn't have to be float? 
    public float range = 100f; //Range of raycast, incase we want a differnt gun??
    public Camera fpsCam; //Camera
    public ParticleSystem muzzelFlash; //Muzzle Flash Enable Disable
    public float fireRate = 15f; //Fire rate of Gun
    private float nextTimeToFire = 0; //Why are adding force?

    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire) //Get the Fire1 button?
        {
            nextTimeToFire = Time.time + 1f / fireRate; 
            Shoot();
        }
    }
    void Shoot()
    {
        muzzelFlash.Play(); // Play partcles
        RaycastHit hit; //When it hits a target
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
           
            Enemy target = hit.transform.GetComponent<Enemy>(); //If it is an enemey NOT a certain type

            if (target != null)
            {
                target.TakeDamage(damage); //Deal DAMAGE to enemey
            }

        }
    }


}

