using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_GetHelp : MonoBehaviour
{
    public GameObject Panel_Help;
    private bool isHelp;

    // Use this for initialization
    void Start()
    {
        isHelp = false;
        Panel_Help.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetHelp()
    {
        if (isHelp)
        {         //提示跳出；
            Panel_Help.SetActive(false);
            isHelp = false;
        }
        else
        {
            Panel_Help.SetActive(true);
            isHelp = true;
        }
    }
}

