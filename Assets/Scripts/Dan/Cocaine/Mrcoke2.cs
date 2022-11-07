using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mrcoke2 : MonoBehaviour
{
    public GameObject[] targets;
    public int speed;
    public float AnimTime;
    int targetIndex;
    public GameObject target;
    public bool Puffed;
    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("CocainePuff");
        targetIndex = Random.Range(0, targets.Length);
        target = targets[targetIndex];
    }
    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CocainePuff"))
        {
            Puffed = true; // for states
            other.gameObject.tag = ("Untagged"); // Ensures that the patch can't be targeted
            GameEvents.CokeTarget?.Invoke(); // event to retarget if need be
        }
    }
    private void OnEnable()
    {
        GameEvents.CokeTarget += Retarget;
    }
    private void OnDisable()
    {
        GameEvents.CokeTarget -= Retarget;
    }
    void Retarget()
    {
        if (target.tag != ("CocainePuff")) // first checks if the current target is no longer a valid target
        {
            StartCoroutine(GetTargets()); // starts the retargetting coroutine
        }
    }
    public IEnumerator GetTargets()
    {
        yield return new WaitForSeconds(AnimTime); // waits until the set time (animation time)
        targets = GameObject.FindGameObjectsWithTag("CocainePuff"); // re-gets the places that can be puffed in
        targetIndex = Random.Range(0, targets.Length); // re-sets the target array
        target = targets[targetIndex]; // gets a new target
    }
}