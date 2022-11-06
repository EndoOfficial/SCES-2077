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
        if(Vector3.Distance(transform.position, player.transform.position) <= distance && toggle)
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
            yield return new WaitForSecondsRealtime(1);
            damage = (int)Mathf.Round(Vector3.Distance(transform.position, player.transform.position));
            //GameEvents.DamagePlayer?.Invoke(damage);
            Debug.Log(tempDamage);
        }
    }
}
