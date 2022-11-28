using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float KillCount;
    public float ItemsCollected;
    public float GameWinCollectCount;
    public float KillsToSpawn;

    public GameObject MrConcaine;
    public Transform CocaineSpawn;

    public List<GameObject> CokeSpawns;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(KillCount >= KillsToSpawn)
        {
            KillCount = 0;
            
                StartCoroutine(SpawnCokeMan());         

            
            
        }
        if(ItemsCollected >= GameWinCollectCount)
        {
            GameEvents.LevelWin?.Invoke();
        }
        
    }

    public IEnumerator SpawnCokeMan()
    {
        float NearestDist = 0;
        GameObject NearestSP = null;

        foreach(GameObject SpawnPoint in CokeSpawns)
        {
            var PlayDist = SpawnPoint.GetComponent<GetDistToPlayer>();

            if(PlayDist != null)
            {
                float dist = PlayDist.PlayerDist;
                if(NearestDist == 0 || dist < NearestDist)
                {
                    NearestDist = dist;
                    NearestSP = SpawnPoint;                    
                }
            }
            //float Dist 
        }

        Debug.Log("SpawnBoss");
        Instantiate(MrConcaine, NearestSP.transform);
        yield return null;
    }
}
