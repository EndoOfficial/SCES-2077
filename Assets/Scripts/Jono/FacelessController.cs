using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FacelessController : MonoBehaviour
{
    public List<AudioClip> SpawnSounds = new List<AudioClip>();
    new AudioClip SpawnNoise;
    new AudioSource audio;
    public float Volume;

    public NavMeshAgent NavMesh;

    public GameObject Player;
    public Rigidbody MyRb;
    public float Speed;
    public bool moveTowards;
    public Animator Anim;

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
        if (moveTowards)
        {            
            transform.Translate(Vector3.forward* Time.deltaTime);
        }
    }
    private void OnDestroy()
    {
        GameController = GameObject.FindGameObjectWithTag("GameManager");
        GameController.GetComponent<GameController>().KillCount += 1;
        Debug.Log("Dead");
        
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.position - transform.position, out hit);

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        //Debug.DrawRay(transform.position, forward, Color.red);

        
        if (CanLunge == true && Physics.Raycast(transform.position, forward, out hit) && hit.collider.tag == "Player")        
        {
            StartCoroutine(Lunge());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Damage");
            damage = 10;
            GameEvents.DamagePlayer(damage);
            Destroy(this.gameObject);
        }
    }
    public IEnumerator Lunge()
    {
        CanLunge = false;
        yield return new WaitForSeconds(5);
        moveTowards = true;
        Anim.SetTrigger("Lunge");
        Debug.Log("Lunge");
        //MyRb.isKinematic = false;
        //MyRb.AddForce((transform.forward) * LungeSpeed);
    }    
}
