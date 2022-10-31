using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mrcoke2 : MonoBehaviour
{
    public  GameObject[] targets;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        int targetIndex = Random.Range(0, targets.Length);
        GameObject target = targets[targetIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed*Time.deltaTime);
    }
}
