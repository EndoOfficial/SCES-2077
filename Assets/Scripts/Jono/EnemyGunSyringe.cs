using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunSyringe : MonoBehaviour
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
    private float bulletSpread = 0.01f;
    public float maxSpread;
    private float tempSpread;
    public float RateOfFire;
    public int damage;
    public float PositionDelay;
    public bool Paused;
    public GroundCheck grounded;
    private void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        tempSpread = bulletSpread;
        StartCoroutine(Position());

        StartCoroutine(Shoot());
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

    private void OnEnable()
    {
        GameEvents.OnPauseGame += PauseGame;
    }
    private void OnDisable()
    {
        GameEvents.OnPauseGame -= PauseGame;
    }
    // Update is called once per frame
    void PauseGame(bool paused)
    {
        Paused = paused;
    }
    //shoot coroutine
    private IEnumerator Shoot()
    {
        yield return new WaitForSecondsRealtime(1f);
        while (true)
        {
            if (!seePlayer)
            {
                yield return null;
            }
            if (Paused)
            {
                yield return null;
            }
            if (!grounded.Grounded && seePlayer)
            {
                //randomizes bulletSpread
                float temp = Random.Range(-bulletSpread, bulletSpread);
                float temp1 = Random.Range(-bulletSpread, bulletSpread);
                float temp2 = Random.Range(-bulletSpread, bulletSpread);

                //get the normalized playerDirection
                bulletDirection = OldPlayerDirection;
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
                
            }
            yield return new WaitForSecondsRealtime(RateOfFire);
        }

    }
    public IEnumerator Position()
    {
        yield return new WaitForSecondsRealtime(PositionDelay);
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
