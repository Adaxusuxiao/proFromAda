using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaohuaBreak : MonoBehaviour {
  
    [SerializeField]
    private GameObject huabinhuatuo;

    [SerializeField]
    private GameObject huae;

    [SerializeField]
    private GameObject huaban;

    [SerializeField]
    private GameObject xiongrui;

    [SerializeField]
    private GameObject cirui;


    [SerializeField]
    private GameObject text_huabin;

    [SerializeField]
    private GameObject text_huatuo;

    [SerializeField]
    private GameObject text_huae;

    [SerializeField]
    private GameObject text_huaban;

    [SerializeField]
    private GameObject text_xiongrui;

    [SerializeField]
    private GameObject text_cirui;

    // public Slider slider;

    private void Start()
    {      
        huabinhuatuo.SetActive(true);
        huaban.SetActive(true);
        huae.SetActive(true);
        xiongrui.SetActive(true);
        cirui.SetActive(true);

        text_huabin.SetActive(true);
        text_huatuo.SetActive(true);
        text_huaban.SetActive(true);
        text_huae.SetActive(true);
        text_xiongrui.SetActive(true);
        text_cirui.SetActive(true);
    }
    private void valueisZero() {
        huabinhuatuo.SetActive(true);
        huaban.SetActive(true);
        huae.SetActive(true);
        xiongrui.SetActive(true);
        cirui.SetActive(true);

        text_huabin.SetActive(true);
        text_huatuo.SetActive(true);
        text_huaban.SetActive(true);
        text_huae.SetActive(true);
        text_xiongrui.SetActive(true);
        text_cirui.SetActive(true);
    }

    private void valueisOne()
    {
        huabinhuatuo.SetActive(false);
        huae.SetActive(true);
        huaban.SetActive(true);
        xiongrui.SetActive(true);
        cirui.SetActive(true);

        text_huabin.SetActive(false);
        text_huatuo.SetActive(false);
        text_huaban.SetActive(true);
        text_huae.SetActive(true);
        text_xiongrui.SetActive(true);
        text_cirui.SetActive(true);
    }

    private void valueisTwo()
    {
        huabinhuatuo.SetActive(false);
        huae.SetActive(false);
        huaban.SetActive(true);
        xiongrui.SetActive(true);
        cirui.SetActive(true);


        text_huabin.SetActive(false);
        text_huatuo.SetActive(false);
        text_huae.SetActive(false);
        text_huaban.SetActive(true);
        text_xiongrui.SetActive(true);
        text_cirui.SetActive(true);
    }
    private void valueisThree()
    {
        huabinhuatuo.SetActive(false);
        huae.SetActive(false);
        huaban.SetActive(false);
        xiongrui.SetActive(true);
        cirui.SetActive(true);


        text_huabin.SetActive(false);
        text_huatuo.SetActive(false);
        text_huaban.SetActive(false);
        text_huae.SetActive(false);
        text_xiongrui.SetActive(true);
        text_cirui.SetActive(true);

    }

    private void valueisFour()
    {
        huabinhuatuo.SetActive(false);
        huae.SetActive(false);
        huaban.SetActive(false);
        xiongrui.SetActive(false);
        cirui.SetActive(true);


        text_huabin.SetActive(false);
        text_huatuo.SetActive(false);
        text_huaban.SetActive(false);
        text_huae.SetActive(false);
        text_xiongrui.SetActive(false);
        text_cirui.SetActive(true);
    }

    public void flowerBreak(Slider slider)
    {
        WithMouseMove.gbIsMove = false;
        if (slider.value == 1)
        {
            valueisOne();
        }else if (slider.value == 2)
        {
            valueisTwo();
        }else if (slider.value == 3)
        {
            valueisThree();
        }else if (slider.value == 4)
        {
            valueisFour();
        }
        else
        {
            valueisZero();
        }

    }

}
