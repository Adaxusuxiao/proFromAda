using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIControl : MonoBehaviour {
    [SerializeField]
    private Text text_temp_H2O;      //当前温度值显示
    [SerializeField]
    private Text text_temp_O2;      //当前温度值显示

    public GameObject go_tempH2O,go_tempO2;

    public static float val_temp_H2O=5;      //当前温度值
    public static float val_temp_O2 = 5;      //当前温度值
    public static bool isNormal=false;    //当前温度值

    

    // Use this for initialization
    void Start () {
        go_tempH2O.SetActive(false);
        go_tempO2.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //slider事件
    public void TempControl_H2O(Slider slider) {
        val_temp_H2O = slider.value;
        text_temp_H2O.text = val_temp_H2O + "℃";
    }

    public void TempControl_O2(Slider slider)
    {
        val_temp_O2 = slider.value;
        text_temp_O2.text = val_temp_O2 + "℃";
    }

    //按钮时间
    public void Btn_world()
    {
        isNormal = !isNormal;
        if (isNormal) {     //在正常世界，不显示温度调节
            go_tempO2.SetActive(false);
            go_tempH2O.SetActive(false);
        }
      
       
    }
}
