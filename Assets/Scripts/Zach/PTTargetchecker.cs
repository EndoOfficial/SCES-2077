using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PTTargetchecker : MonoBehaviour
{
    //same as EnemyCounter script but instead rotates a door
    public GameObject door;
    public int Enemy;
    void Start()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        StartCoroutine(Checker());
    }

    private IEnumerator Checker()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (Enemy <= 0)
        {
            door.transform.Rotate(0, 90, 0);
        }
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Checker());
    }

}
