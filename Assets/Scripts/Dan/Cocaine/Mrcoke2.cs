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
            Puffed = true;
            other.gameObject.tag = ("Untagged");
            GameEvents.CokeTarget?.Invoke();
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
        if (target.tag != ("CocainePuff"))
        {
            StartCoroutine(GetTargets());
        }
    }
    public IEnumerator GetTargets()
    {
        yield return new WaitForSeconds(AnimTime);
        targets = GameObject.FindGameObjectsWithTag("CocainePuff");
        targetIndex = Random.Range(0, targets.Length);
        target = targets[targetIndex];
    }
}