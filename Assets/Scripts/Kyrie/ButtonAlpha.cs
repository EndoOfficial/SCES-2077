using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonAlpha : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public Image image;
    private void Awake()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;
    }


    void Start()
    {

        image = GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 0f;
        image.color = tempColor;

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0f;
        Debug.Log("Highlighted");
        image = GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 1f;
        image.color = tempColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;
        Debug.Log("Unhighlighted");
        image = GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 0f;
        image.color = tempColor;
    }

}
