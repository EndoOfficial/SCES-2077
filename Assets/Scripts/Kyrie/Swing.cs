using UnityEngine;
using System.Collections;

public class Swing : MonoBehaviour
{
    [SerializeField] protected Vector3 m_from = new Vector3(45.0F, 0.0F, 0.0F);
    [SerializeField] protected Vector3 m_to = new Vector3(-45.0F, 0.0F, 0.0F);
    [SerializeField] protected float m_frequency = 1.0F;

    void Update()
    {
        Quaternion from = Quaternion.Euler(this.m_from);
        Quaternion to = Quaternion.Euler(this.m_to);

        float lerp = 0.5F * (1.0F + Mathf.Sin(Mathf.PI * Time.realtimeSinceStartup * this.m_frequency));
        this.transform.localRotation = Quaternion.Lerp(from, to, lerp);
    }
}