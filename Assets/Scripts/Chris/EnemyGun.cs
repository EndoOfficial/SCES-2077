using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject player;
    private Animator anim;

    private bool canSeePlayerRay;
    private bool shootAtPlayerRay;
    public bool seePlayer;
    private Vector3 playerDirection;
    private Vector3 OldPlayerDirection;
    private Vector3 bulletDirection;
    public LayerMask playerMask;
    public float bulletSpread;
    public float maxSpread;
    private float tempSpread;
    public float attackSpeed;
    public int damage;
    public float delay;
    public bool Paused;

    private void Start()
    {
        StartCoroutine(Shoot());
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        tempSpread = bulletSpread;
        StartCoroutine(Position());
    }
    private void OnEnable()
    {
        GameEvents.OnPauseGame += PauseGame;
    }
    private void OnDisable()
    {
        GameEvents.OnPauseGame -= PauseGame;
    }

    void PauseGame(bool paused)
    {
        Paused = paused;
    }
    private void FixedUpdate()
    {
        //gets player direction

        playerDirection = player.transform.position - transform.position;

        //playerDirection = playerDirection;

        //if enemy can see player
        if (canSeePlayerRay = Physics.Raycast(transform.position, playerDirection, out RaycastHit hitinfo))
        {
            if (hitinfo.transform.CompareTag("Player") && !seePlayer)
            {
                seePlayer = true;
            }
            else if (!hitinfo.transform.CompareTag("Player") && seePlayer)
            {
                seePlayer = false;
                bulletSpread = tempSpread;
            }
        }
    }

    //shoot coroutine
    private IEnumerator Shoot()
    {
        yield return new WaitForSecondsRealtime(1f);
        while (true)
        {
            if(seePlayer && !Paused)
            {
                //randomizes bulletSpread
                float temp = Random.Range(-bulletSpread, bulletSpread);
                float temp1 = Random.Range(-bulletSpread, bulletSpread);
                float temp2 = Random.Range(-bulletSpread, bulletSpread);

                //get the normalized playerDirection
                bulletDirection = OldPlayerDirection.normalized;
                //applies the random bulletspread to the bullet direction
                bulletDirection = new Vector3(
                    bulletDirection.x + temp,
                    bulletDirection.y + temp1,
                    bulletDirection.z + temp2);

                //if the ray hits the player
                if (shootAtPlayerRay = Physics.Raycast(transform.position, bulletDirection, out RaycastHit hitinfo))
                {
                    anim.SetTrigger("Shoot");
                    if (hitinfo.transform.CompareTag("Player"))
                    {
                        GameEvents.DamagePlayer?.Invoke(damage);
                    }
                }
                //increases spread every shot
                if (bulletSpread <= maxSpread)
                {
                    bulletSpread += 0.01f;
                }
                yield return new WaitForSecondsRealtime(attackSpeed);
            }
        }
    }
    public IEnumerator Position()
    {
        yield return new WaitForSecondsRealtime(delay);
        OldPlayerDirection = playerDirection;
        StartCoroutine(Position());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, bulletDirection);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, playerDirection);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, OldPlayerDirection);
    }
}
