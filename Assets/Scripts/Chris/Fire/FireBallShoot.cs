using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallShoot : MonoBehaviour
{
    public int damage;
    public float FireRate;
    public GameObject fireBall;

    public void ShootStart()
    {
        StartCoroutine(Shoot());
    }

    public void ShootStop()
    {
        StopAllCoroutines();
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(FireRate);
            var obj = Instantiate(fireBall, transform.position, transform.rotation);
            obj.GetComponent<FireBallProjectile>().damage = damage;
        }
    }
}
