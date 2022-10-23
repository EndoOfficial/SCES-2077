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
    private bool gamePaused;

    public void Update()
    {
        if (gamePaused)
        {
            return;
        }
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

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, EnemyLayer))
            {
                //damage enemy Event
                Debug.Log("Damage");
                GameEvents.DamageEnemy?.Invoke(damage, hit.transform.gameObject);
            }
        }
    }
    private void OnEnable()
    {
        GameEvents.OnPauseGame += OnPauseGame;
    }

    private void OnDisable()
    {
        GameEvents.OnPauseGame -= OnPauseGame;
    }
    public void OnPauseGame( bool paused)
    {
        gamePaused = paused;
    }
}