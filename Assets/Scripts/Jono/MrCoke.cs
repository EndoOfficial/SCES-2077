using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrCoke : MonoBehaviour
{
    public GameObject ItemSpawner;

    public AudioClip SpawnNoise;
    new AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        Debug.Log("Hello");
        StartCoroutine(GiveOrder());
        audio.PlayOneShot(SpawnNoise);
    }

    public IEnumerator GiveOrder()
    {
        yield return new WaitForSeconds(5);
        //Instantiate(ItemSpawner);
        ItemSpawner = GameObject.FindGameObjectWithTag("ItemSpawner");
        ItemSpawner.GetComponent<ItemSpawner>().CanSpawn = true;
        Destroy(gameObject);

    }
}
