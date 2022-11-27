using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CellCalculations : MonoBehaviour
{
    private int First;
    private int Second;
    public int damage;
    public TextMeshPro DamageInt;
    private CellSpawner CellManager;
    public int RndColour;
    // Start is called before the first frame update
    void Start()
    {
        CellManager = GameObject.FindWithTag("SpreadSheet").GetComponent<CellSpawner>();

        if (Random.value < 0.5f)
            RndColour = 0;
        else RndColour = 255;

        if (CellManager.State2 == true)
        {
            if (name == "TakeDamageCell(Clone)")
            {
                DamageInt.color = Color.white;
            }
            else if (name == "DealDamageCell(Clone)")
            {
                DamageInt.color = Color.red;
            }
        }

        if (CellManager.State3 == true)
        {
            if (name == "TakeDamageCell(Clone)")
            {
                DamageInt.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
            }
            else if (name == "DealDamageCell(Clone)")
            {
                DamageInt.color = new Color(255, RndColour, RndColour);
            }
        }
        First = Random.Range(11, 15);
        Second = Random.Range(0, 10);
        damage = First - Second;
        DamageInt.text = First + "-" + Second;
    }
}
