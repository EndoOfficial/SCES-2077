using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheHandController : MonoBehaviour
{
    public GameObject HandsCentrePos;
    public GameObject BarrelHolder;
    public GameObject Bucket;
    public float MaxDist;
    public float Speed;
    public Vector3 ThrowForce;
    public bool MoveLeft;
    public bool SpawnBucket;
    public bool playerDetected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        Debug.Log(BarrelHolder.transform.childCount);
        if (MoveLeft)
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector3.right * Speed * Time.deltaTime);
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
    }
    void FixedUpdate()
    {
        
        RaycastHit hit;
        Physics.Raycast(transform.position, HandsCentrePos.transform.position - transform.position, out hit);
        



        if (transform.position.x > MaxDist)
        {
            Debug.DrawRay(transform.position, HandsCentrePos.transform.position - transform.position, Color.yellow);
            MoveLeft = MoveLeft ? false : true;
        }    
        
        if(transform.position.x < -MaxDist)
        {
            Debug.DrawRay(transform.position, HandsCentrePos.transform.position - transform.position, Color.green);
            MoveLeft = MoveLeft ? false : true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerDetected = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerDetected = false;
        }
    }

    public IEnumerator SpawnNewBucket()
    {
        SpawnBucket = false;
        yield return new WaitForSeconds(2);
        var newBucket = Instantiate(Bucket, (BarrelHolder.transform.position), Quaternion.Euler(0, 0, 90));
        newBucket.transform.parent = BarrelHolder.transform;
        
        yield return new WaitForSeconds(2);
    }

    public IEnumerator ThrowBucket()
    {
        
        var child = BarrelHolder.gameObject.transform.GetChild(0).gameObject;
        child.transform.parent = null;
        child.GetComponent<Rigidbody>().isKinematic = false;
        child.GetComponent<Rigidbody>().useGravity = true;
        SpawnBucket = true;
        Debug.Log("yeet");
        ThrowForce.z = Random.Range(-5, -20);
        child.GetComponent<Rigidbody>().AddRelativeForce(ThrowForce, ForceMode.Impulse);
        yield return new WaitForSeconds(2);


    }
}
