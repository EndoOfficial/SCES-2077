using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CellDamage : MonoBehaviour
{
    private int First;
    private int Second;
    public int damage;
    public TextMeshPro DamageInt;
    // Start is called before the first frame update
    void Start()
    {
        First = Random.Range(11, 15);
        Second = Random.Range(0, 10);
        damage = First - Second;
        DamageInt.text = First + "-" + Second;
    }
}
