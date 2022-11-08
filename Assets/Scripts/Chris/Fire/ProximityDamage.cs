using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityDamage : MonoBehaviour
{
    private GameObject player;
    public float distance;
    private bool toggle;
    public int damage;
    private int tempDamage;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= distance && toggle)
        {
            toggle = false;
            StartCoroutine(Constant());
        }
        else if (Vector3.Distance(transform.position, player.transform.position) >= distance)
        {
            toggle = true;
            StopAllCoroutines();
        }
    }

    private IEnumerator Constant()
    {
        while (true)
        {
            var dam = (int)(Vector3.Distance(transform.position, player.transform.position) + 1);

            GameEvents.DamagePlayer?.Invoke(damage);
            yield return new WaitForSecondsRealtime(1);
        }
    }
}
