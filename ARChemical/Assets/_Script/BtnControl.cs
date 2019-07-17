using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnControl : MonoBehaviour {
    public GameObject usetips;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Btn_shuaxin()
    {
        SceneManager.LoadScene("SceneWater");
    }

    public void Btn_tuichu() {
        Application.Quit();
    }

    public void Btn_closetips() {
        usetips.SetActive(false);
    }

    public void Btn_gettips()
    {
        usetips.SetActive(true);
    }
}
