using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject player;
    private bool canSeePlayer;
    private bool shootAtPlayer;
    private bool seePlayer;
    private Vector3 playerDirection;
    private Vector3 bulletDirection;
    public LayerMask playerMask;
    private Ray ray;
    public float bulletSpread;
    public float attackSpeed;
    public int damage;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        //gets player direction
        playerDirection = player.transform.position - transform.position;
        //playerDirection = playerDirection;

        ray = new Ray(transform.position, bulletDirection);

        //if enemy can see player
        if (canSeePlayer = Physics.Raycast(transform.position, playerDirection, out RaycastHit hitinfo))
        {
            if (hitinfo.transform.CompareTag("Player") && !seePlayer)
            {
                seePlayer = true;
                StartCoroutine(Shoot());
            }
            else if (!hitinfo.transform.CompareTag("Player") && seePlayer)
            {
                seePlayer = false;
                bulletSpread = 0.1f;
                attackSpeed = 0.5f;
                StopAllCoroutines();
            }
        }
    }
    
    //shoot coroutine
    private IEnumerator Shoot()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        while (true)
        {
            //randomizes bulletSpread
            float temp = Random.Range(-bulletSpread, bulletSpread);
            float temp1 = Random.Range(-bulletSpread, bulletSpread);
            float temp2 = Random.Range(-bulletSpread, bulletSpread);

            //get the normalized playerDirection
            bulletDirection = playerDirection.normalized;
            //applies the random bulletspread to the bullet direction
            bulletDirection = new Vector3(
                bulletDirection.x + temp,
                bulletDirection.y + temp1,
                bulletDirection.z + temp2);

            //if the ray hits the player
            if (shootAtPlayer = Physics.Raycast(transform.position, bulletDirection, out RaycastHit hitinfo))
            {
                Debug.Log("BANG!!");
                if (hitinfo.transform.CompareTag("Player"))
                {
                    GameEvents.DamagePlayer?.Invoke(damage);

                }
                
            }
            //increases spread every shot
            if (bulletSpread <= 0.1f)
            {
                bulletSpread += 0.01f;
            }
            yield return new WaitForSecondsRealtime(attackSpeed);
        }

    }
}
