using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectables : MonoBehaviour
{
    public GameObject Presentable;

    public void PresentCollect()
    {
         Presentable.SetActive(true);
    }

    public void DisableCollect()
    {
        Presentable.SetActive(false);
    }

}