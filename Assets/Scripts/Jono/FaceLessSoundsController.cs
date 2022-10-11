using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceLessSoundsController : MonoBehaviour
{
    public GameObject Player;
    public float RotateSpeed;
    public float timer;
    public GameObject FacelessFella;
    public bool CanSpawn;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        //transform.SetParent(Player.gameObject.transform);
        timer = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Player.transform.position, Vector3.up, RotateSpeed * Time.deltaTime);
        transform.position = Player.transform.position;
        timer -= Time.deltaTime;
        if (timer < 0 && CanSpawn)
        {
            
            StartCoroutine(SpawnFaceless());
            
        }
    }



    public IEnumerator SpawnFaceless()
    {
        CanSpawn = false;
        Debug.Log("Psst");
        RotateSpeed = 0;
        var NewFaceless = Instantiate(FacelessFella, this.gameObject.transform.GetChild(0).position, Quaternion.identity);
        yield return new WaitForSeconds(5);
        timer = Random.Range(1f, 10f);
        CanSpawn = true;
        RotateSpeed = 50;
    }
}
