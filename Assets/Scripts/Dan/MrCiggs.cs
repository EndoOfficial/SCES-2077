using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrCiggs : MonoBehaviour
{
    public Transform target;
    public float health = 100f;
    public float range = 100f;
    public ParticleSystem muzzelflashBoss;
    public float damage = 1;


    public void Update()
    {
        Vector3 direction = target.transform.position- transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation=rotation;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    public void Shoot()
    {
        Debug.Log("isShooting");
        muzzelflashBoss.Play();

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.Log("damage" + hit);
            Health target = hit.transform.GetComponent<Health>();
            Debug.Log(target);
            if (target != null)
            {
                target.TakeDamage(damage);
            }


        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.forward);
    }
}
