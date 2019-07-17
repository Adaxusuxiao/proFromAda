using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BtnCover : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public Image intro_scence;



    // Use this for initialization
    void Start () {
        intro_scence.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        intro_scence.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        intro_scence.enabled = false;
    }


}
