using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioCycle))]
public class Gun : MonoBehaviour
{
    public int damage = 10;
    public Camera fpsCam;
    public float impactForce = 30f;
    public float fireRate = 15f;
    private float nextTimeToFire = 0;
    public Animator anim;
    public GameObject bulletHit;
    public GameObject enemyHit;
    public GameObject paperHit;
    public TrailRenderer bulletTrail;
    public GameObject bulletSpawn;
    private AudioCycle audioCycle;

    public void Start()
    {
        audioCycle = GetComponent<AudioCycle>();
    }
    public void Update()
    {
        //checks for mouse1 and nextTimeToFire
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            GameEvents.OnUniversalplayAudio?.Invoke(audioCycle.GetNextAudioSource(), AudioManager.UniversalClipTags.Gunfire);
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

    }
    void Shoot()
    {
        anim.SetTrigger("Shoot");

        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            TrailRenderer trail = Instantiate(bulletTrail, bulletSpawn.transform.position, Quaternion.identity);
            StartCoroutine(SpawnTrail(trail, hit));
        }
    }
    private IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit hit)
    {
        float time = 0;
        Vector3 startposition = trail.transform.position;

        while(time < 3)
        {
            trail.transform.position = Vector3.Lerp(startposition, hit.point, time);
            time += Time.deltaTime / trail.time;

            yield return null;
        }
        trail.transform.position = hit.point;
        if (hit.transform != null)
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                //damage enemy Event
                GameEvents.DamageEnemy?.Invoke(damage, hit.transform.gameObject); //This passes though a damage and the object that GET'S HIT
                Instantiate(enemyHit, hit.point, bulletSpawn.transform.rotation);

                WeakPoints target = hit.transform.GetComponent<WeakPoints>();
                if (target != null)
                {
                    GameEvents.DamageEnemy?.Invoke(damage, hit.transform.parent.gameObject);
                    target.Shot();
                }
            }
            else if (hit.transform.CompareTag("Paper"))
            {
                Instantiate(paperHit, hit.point, bulletSpawn.transform.rotation);
            }
            else if (hit.transform.CompareTag("Nose"))
            {

            }
            else if (hit.transform.CompareTag("Player"))
            {
            }
            else
            {
                Instantiate(bulletHit, hit.point + (hit.normal * .01f), Quaternion.FromToRotation(Vector3.forward, hit.normal));
            }
        }
        Destroy(trail.gameObject, trail.time);
    }
}