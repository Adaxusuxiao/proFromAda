using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BtnControl : MonoBehaviour {
    [SerializeField]
    private AudioSource introradio;
    // Use this for initialization

    
    public GameObject gotool;

    [SerializeField]
    private Button btn_tw;


    public Sprite[] btntw_pics = new Sprite[2];
    private bool isgetTool = false;

    public Animator goanimator;
    public Animator XrAnimator;


    public GameObject cirui;


    public Image tiptool;
    public Image tipflower;



    public void Btn_introplay() {       
        introradio.Play();
    }

    public void ChangeScence1()
    {
        SceneManager.LoadScene("FlowerMain1", LoadSceneMode.Single);
    }

    public void ChangeScence2()
    {
        SceneManager.LoadScene("FlowerXiongrui2", LoadSceneMode.Single);
    }

    public void ChangeScence3()
    {
        SceneManager.LoadScene("FlowerCirui3", LoadSceneMode.Single);
    }

    public void Btn_Tool()                 //获取镊子、刀片
    {
        if (!isgetTool) { 
        btn_tw.GetComponent<Image>().sprite = btntw_pics[1];
            gotool.gameObject.SetActive(true);
            isgetTool = !isgetTool;
            tipflower.enabled = true;
            tiptool.enabled = false;                  
        }
    }

    public void Btn_triggerAni()         //刀切雌蕊
    {
        goanimator.enabled = true;
        tipflower.enabled = false;
        goanimator.SetBool("getAnmiator", true);
        cirui.GetComponent<ChangeRotate>().enabled = true;
        gameObject.SetActive(false);
        tipflower.enabled = false;

    }

    public void Btn_triggerTw()         //镊子取花药
    {
        tipflower.enabled = false;
        cirui.GetComponent<ChangeRotate>().enabled = true;
        gameObject.SetActive(false);
        tipflower.enabled = false;
        gotool.SetActive(false);

    }
        public void Btn_disXrui()
    {
        XrAnimator.SetBool("isShow", true);
    }


}
