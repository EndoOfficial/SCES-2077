using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    private CellSpawner CellManager;
    // Start is called before the first frame update
    void Start()
    {
        CellManager = GameObject.FindWithTag("SpreadSheet").GetComponent<CellSpawner>();

    }
    private void OnEnable()
    {
        GameEvents.CellsShot += EyeCheck;
    }
    private void OnDisable()
    {

        GameEvents.CellsShot -= EyeCheck;
    }
    private void EyeCheck()
    {
        StartCoroutine(Delay());
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(.1f);
        if (CellManager.State2 == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        if (CellManager.State3 == true)
        {
            if (name == "Right")
            {
                gameObject.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}