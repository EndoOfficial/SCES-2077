using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheHandController : MonoBehaviour
{
    public GameObject HandsCentrePos;
    public GameObject BarrelHolder;
    public GameObject Bucket;
    public GameObject PlayerDetector;
    public float MaxDist;
    public float Speed;
    public Vector3 ThrowForce;
    public bool MoveLeft;
    public bool SpawnBucket;
    public bool playerDetected;
    public bool Invulnarable;
    public Transform CentrePoint;
    public float timer;
    public BoxCollider Col;
    public Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(0, 3);
    }

    private void Update()
    {
        playerDetected = PlayerDetector.GetComponent<PlayerDetection>().playerDetected;
        timer -= Time.deltaTime;

        if(timer <= 0 && !SpawnBucket)
        {
            StartCoroutine(ThrowBucket());
            MoveLeft = MoveLeft ? false : true;
            timer = Random.Range(5, 15);
            
        }

        if (Invulnarable)
        {
            Col.enabled = false;
        }
        else
        {
            Col.enabled = true;
        }

        Debug.Log(BarrelHolder.transform.childCount);
        if (MoveLeft)
        {
            transform.RotateAround(CentrePoint.position, Vector3.up, Speed * Time.deltaTime);
            //transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(CentrePoint.position, Vector3.up, -Speed * Time.deltaTime);
            //transform.Translate(-Vector3.right * Speed * Time.deltaTime);
        }

        if(BarrelHolder.transform.childCount == 0 && SpawnBucket)
        {          
            StartCoroutine(SpawnNewBucket());            
        }
        if(BarrelHolder.transform.childCount > 0 && !SpawnBucket && playerDetected)
        {
            StopCoroutine(SpawnNewBucket());
            StartCoroutine(ThrowBucket());
        }

        if(GetComponent<Enemy>().health <= 0)
        {
            //GameEvents.LevelWin?.Invoke();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Enemy"))
        {
            MoveLeft = MoveLeft ? false : true;
        }
    }
    void FixedUpdate()
    {
        
        //RaycastHit hit;
        //Physics.Raycast(transform.position, HandsCentrePos.transform.position - transform.position, out hit);
        



        //if (transform.position.x > MaxDist)
        //{
        //    Debug.DrawRay(transform.position, HandsCentrePos.transform.position - transform.position, Color.yellow);
        //    MoveLeft = MoveLeft ? false : true;
        //}    
        
        //if(transform.position.x < -MaxDist)
        //{
        //    Debug.DrawRay(transform.position, HandsCentrePos.transform.position - transform.position, Color.green);
        //    MoveLeft = MoveLeft ? false : true;
        //}
    }

    

    public IEnumerator SpawnNewBucket()
    {
        Anim.SetTrigger("HasBucket");
        Invulnarable = true;
        SpawnBucket = false;
        yield return new WaitForSeconds(Random.Range(2 , 5));
        Invulnarable = false;
        var newBucket = Instantiate(Bucket, (BarrelHolder.transform));
        
        
        
        yield return new WaitForSeconds(2);
    }

    public IEnumerator ThrowBucket()
    {
        Anim.SetTrigger("Throw");
        GameEvents.OnRuralplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.RuralClipTags.Whoosh);
        var child = BarrelHolder.gameObject.transform.GetChild(0).gameObject;
        child.transform.parent = null;
        child.GetComponent<Rigidbody>().isKinematic = false;
        child.GetComponent<Rigidbody>().useGravity = true;
        SpawnBucket = true;
        Debug.Log("yeet");
        ThrowForce.z = Random.Range(-5, -20);
        child.GetComponent<Rigidbody>().AddRelativeForce(ThrowForce, ForceMode.Impulse);       
        yield return new WaitForSeconds(2);
        Anim.SetTrigger("NoHasBucket");

    }
}
