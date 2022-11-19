using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float KillCount;
    public float ItemsCollected;
    public float GameWinCollectCount;

    public GameObject MrConcaine;
    public Transform CocaineSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(KillCount >= 2)
        {
            KillCount = 0;
            if(CocaineSpawn && MrConcaine != null)
            {
                Instantiate(MrConcaine, CocaineSpawn);
            }

            else
            {
                
            }
            
        }
        if(ItemsCollected >= GameWinCollectCount)
        {
            GameEvents.LevelWin?.Invoke();
        }
        
    }
}
