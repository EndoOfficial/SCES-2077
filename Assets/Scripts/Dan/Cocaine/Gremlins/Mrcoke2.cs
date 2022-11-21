using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Mrcoke2 : MonoBehaviour
{
    public float Cooldown;
    private GameObject[] targets;
    public int speed;
    public float AnimTime;
    int targetIndex;
    public GameObject target;
    public int damage;
    private bool hit;
    public LayerMask Player;
    public float radius;
    public GameObject CokeChecker;
    public bool Melee;
    private NavMeshAgent _agent;
    void Start()
    {
        CokeChecker = GameObject.Find("CocaineCheck");
        targets = GameObject.FindGameObjectsWithTag("CocainePuff");
        targetIndex = Random.Range(0, targets.Length);
        target = targets[targetIndex];
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(target.transform.position);

    }
    public void Update()
    {
        transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
        transform.position += transform.forward * speed * Time.deltaTime;
        if (Physics.CheckSphere(transform.position, radius, Player))
        {
            if (!hit)
            {
                hit = true;
                StartCoroutine(HitDelay());
                GameEvents.DamagePlayer?.Invoke(damage);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CocainePuff"))
        {
            other.gameObject.tag = ("Untagged"); // Ensures that the patch can't be targeted
            GameEvents.CokeTarget?.Invoke(); // Event to retarget if need be
            Retarget();
        }

       
    }
    private IEnumerator HitDelay()
    {
        yield return new WaitForSeconds(Cooldown);
        hit = false;
    }
    private void OnEnable()
    {
        GameEvents.CokeTarget += Retarget;
    }
    private void OnDisable()
    {
        GameEvents.CokeTarget -= Retarget;
    }
    public void Retarget()
    {
        if (target.tag != ("CocainePuff")) // first checks if the current target is no longer a valid target
        {
            Debug.Log($"Retarget");
            StartCoroutine(GetTargets()); // starts the retargetting coroutine
        }
    }
    public IEnumerator GetTargets()
    {
        yield return new WaitForSeconds(AnimTime); // waits until the set time (animation time)
        targets = GameObject.FindGameObjectsWithTag("CocainePuff"); // re-gets the places that can be puffed in
        if (targets.Length <= 0)
        {
            yield break;
        }
        Debug.Log($"NewTarget{target.name}");
        targetIndex = Random.Range(0, targets.Length); // re-sets the target array
        target = targets[targetIndex]; // gets a new target
        _agent.SetDestination( target.transform.position);
        _agent.speed += 5;
    }
    
}