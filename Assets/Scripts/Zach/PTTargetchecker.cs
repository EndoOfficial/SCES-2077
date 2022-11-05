using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PTTargetchecker : MonoBehaviour
{
    //same as EnemyCounter script but instead rotates a door
    public GameObject door;
    public GameObject nextArea;
    public GameObject lastArea; 
    public int Enemy;
    private bool doorOpen;

    private void OnEnable()
    {
        GameEvents.DoorClose += DoorCloser;
    }
    private void OnDisable()
    {
        GameEvents.DoorClose -= DoorCloser;
    }
    private void Start()
    {
        doorOpen = false;
        Enemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        StartCoroutine(Checker());
    }

    private IEnumerator Checker() //checks if all the targets have been killed and if so the door opens, gets set as open via bool
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (doorOpen == false && Enemy <= 0)
        {
            door.transform.RotateAround (door.transform.position, Vector3.up, 90);
            doorOpen = true;
            nextArea.SetActive(true);
        }
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Checker());
    } 
    void DoorCloser() //Closes the door and disables the last area, sets door as closed (activated via events
    {
        if (doorOpen == true)
        {
            doorOpen = false;
            door.transform.Rotate(0, -90, 0);
            lastArea.SetActive(false);
            Debug.Log("A");
        }
        else
        {
            Debug.Log("B");
            return;
        }
    }
}
