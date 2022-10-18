using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacelessController : MonoBehaviour
{
    public List<AudioClip> SpawnSounds = new List<AudioClip>();
    new AudioClip SpawnNoise;
    new AudioSource audio;
    public float Volume;

    public GameObject Player;
    public Rigidbody MyRb;
    public float LungeSpeed;

    public bool CanLunge;

    private int damage;
    public GameObject GameController;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        SpawnNoise = SpawnSounds[Random.Range(0, SpawnSounds.Count)];
        audio.PlayOneShot(SpawnNoise);

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {        
        
    }
    private void OnDestroy()
    {
        GameController = GameObject.FindGameObjectWithTag("GameManager");
        GameController.GetComponent<GameController>().KillCount = GameController.GetComponent<GameController>().KillCount + 1;
        Debug.Log("Dead");
        
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.position - transform.position, out hit);

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.red);

        if (Physics.Raycast(transform.position, forward, out hit) && hit.collider.tag == "Player" && CanLunge == true)        
        {
            StartCoroutine(Lunge());
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            damage = 10;
            GameEvents.DamagePlayer(damage);
            
        }
    }
    public IEnumerator Lunge()
    {
        CanLunge = false;
        yield return new WaitForSeconds(5);
        MyRb.isKinematic = false;
        MyRb.AddForce((transform.forward) * LungeSpeed);
    }    
}
