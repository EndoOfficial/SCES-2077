using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FacelessController : MonoBehaviour
{
    public List<AudioClip> SpawnSounds = new List<AudioClip>();
    new float SpawnNoise;
    new AudioSource audio;
    public float Volume;

    public NavMeshAgent NavMesh;

    public GameObject Player;
    public Rigidbody MyRb;
    public float Speed = 10;
    public bool moveTowards;
    public Animator Anim;

    public bool CanLunge;
    public bool HitPlayer;

    private int damage;
    public GameObject GameController;
    // Start is called before the first frame update
    void Start()
    {
        //audio = GetComponent<AudioSource>();

        GameController = GameObject.FindGameObjectWithTag("GameManager");
        SpawnNoise = Random.Range(1, 5);
        Debug.Log(SpawnNoise);        

        if (SpawnNoise == 1)
        {
            GameEvents.OnCorporateplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.CorporateClipTags.FacelessSound1);
        }
        if (SpawnNoise == 2)
        {
            GameEvents.OnCorporateplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.CorporateClipTags.FaceLessSound2);
        }
        if (SpawnNoise == 3)
        {
            GameEvents.OnCorporateplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.CorporateClipTags.FacelessSound3);
        }
        if (SpawnNoise == 4)
        {
            GameEvents.OnCorporateplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.CorporateClipTags.FacelessSound4);
        }
        if (SpawnNoise == 5)
        {
            GameEvents.OnCorporateplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.CorporateClipTags.FacelessSound5);
        }
        if (SpawnNoise == 6)
        {
            GameEvents.OnCorporateplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.CorporateClipTags.FacelessSound6);
        }
        if (SpawnNoise == 7)
        {
            GameEvents.OnCorporateplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.CorporateClipTags.FacelessSound7);
        }

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTowards)
        {            
            transform.Translate(Vector3.forward* Time.deltaTime * Speed);
        }        

        if(GetComponent<Enemy>().health <= 0)
        {
            Speed = 0;
            GetComponent<Collider>().enabled = false; 
        }
    }
    

    private void FixedUpdate()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.position - transform.position, out hit);

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        //Debug.DrawRay(transform.position, forward, Color.red);

        
        if (CanLunge == true && Physics.Raycast(transform.position, forward, out hit) && hit.collider.tag == "Player")        
        {
            StartCoroutine(StartLunge());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !HitPlayer)
        {
            HitPlayer = true;
            Debug.Log("Damage");
            damage = 10;
            GameEvents.DamagePlayer(damage);
            Destroy(this.gameObject);
        }
    }
    public IEnumerator StartLunge()
    {
        
        CanLunge = false;
        yield return new WaitForSeconds(4);
        Anim.SetTrigger("Lunge");
        
        //MyRb.isKinematic = false;
        //MyRb.AddForce((transform.forward) * LungeSpeed);
    }    
    public void Lunge()
    {
        moveTowards = true;
        GetComponent<Enemy>().health = 10;
        Speed = 12;
        Debug.Log("Lunge");
    }

    public void AddKillCount()
    {
        GameController.GetComponent<GameController>().KillCount += 1;
        Debug.Log("Dead");
    }
}
