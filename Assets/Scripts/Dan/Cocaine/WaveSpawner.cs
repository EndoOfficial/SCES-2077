using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING,WAITING,COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float spawnRate;
    }
    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;
    public float timeBeetweenWave = 5;
    private float waveCountDown;

    private float searchCountdown = 1;
    private SpawnState state = SpawnState.COUNTING;

    private void Start()
    {
        
        waveCountDown = timeBeetweenWave;

    }
    private void Update()
    {
        if(state== SpawnState.WAITING)
        {
            if (EnemyIsAlive()==false)
            {
                WaveCompleated();
                Debug.Log("Completed Current Wave");
                //GameEvents.NewWave?.Invoke();
            }
            else
            {
                return;
            }
        }
        if(waveCountDown > 0)
        {
            if(state!= SpawnState.SPAWNING)
            {
                Debug.Log("New Wave");
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
            else
            {
                waveCountDown -= Time.deltaTime;
            }
        }
    }
    void WaveCompleated()
    {
        state = SpawnState.COUNTING;
        waveCountDown=timeBeetweenWave;
        if(nextWave+1 > waves.Length - 1)
        {
            
           
            nextWave = 0;
            //GameEvents.LevelWin?.Invoke();
            Debug.Log("Compleated all waves");
        }
        else
        {
            //GameEvents.WaveWin?.Invoke();
            Debug.Log("new Wave");
            nextWave++;
        }
       
    }
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            Debug.Log($"EnemyIsAlive: {GameObject.FindGameObjectsWithTag("Enemy").Length}");

            if (GameObject.FindGameObjectsWithTag("Enemy").Length==0)
                {
              
                Debug.Log("All enemies dead");
                return false;
            }
        }
        
        return true;
    }
    IEnumerator SpawnWave(Wave _wave)
    {
        //GameEvents.NewWave?.Invoke();
        state = SpawnState.SPAWNING;
        for (int i = 0; i < _wave.count; i++)
        {
            Debug.Log("Spawn New Enemy");
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1/_wave.spawnRate);
        }

        state = SpawnState.WAITING;
        Debug.Log("Waiting for next Wave");
        yield break;
    }
    void SpawnEnemy(Transform _enemy)
    {
       
        Transform _sp= spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position,_sp.rotation);
    }
}
