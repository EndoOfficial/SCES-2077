using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 10;
    public Camera fpsCam;
    public float impactForce = 30f;
    public float fireRate = 15f;
    private float nextTimeToFire = 0;
    public LayerMask EnemyLayer;
    public Animator anim;
    public GameObject bulletHit;

    public void Update()
    {
        //checks for mouse1 and nextTimeToFire
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

    }
    void Shoot()
    {
        anim.SetTrigger("Shoot");
        FindObjectOfType<AudioManager>().Play("Shooting");
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, EnemyLayer))
        {
            //damage enemy Event
            GameEvents.DamageEnemy?.Invoke(damage, hit.transform.gameObject); //This passes though a damage and the object that GET'S HIT
            Instantiate(bulletHit, hit.point, gameObject.transform.rotation);

            WeakPoints target = hit.transform.GetComponent<WeakPoints>();
            if (target != null)
            {
                GameEvents.DamageEnemy?.Invoke(damage, hit.transform.parent.gameObject);
                target.Shot();
            }
        }
    }
}