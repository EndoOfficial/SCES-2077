using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public bool Spawning;
    public int Enemy;    
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if ( Enemy <= 0)
        {
            GameEvents.LevelWin?.Invoke();
        }
        
    }
}
