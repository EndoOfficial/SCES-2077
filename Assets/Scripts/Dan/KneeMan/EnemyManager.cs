using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public float WaitTime;
    public List<GameObject> Doors;
    public int numEnemies;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < numEnemies; i++)
        {
            yield return new WaitForSeconds(WaitTime);
            Instantiate(EnemyPrefab,Doors[i].transform.position, Quaternion.identity);
        }
    }
}
