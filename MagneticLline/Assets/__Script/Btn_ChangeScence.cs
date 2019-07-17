using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_ChangeScence : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToContent()
    {
        SceneManager.LoadScene("MagneticContents", LoadSceneMode.Single);
    }

    public void ToField()
    {
        SceneManager.LoadScene("MagneticField", LoadSceneMode.Single);
    }

    public void ToLearn()
    {
        SceneManager.LoadScene("MagneticLearn", LoadSceneMode.Single);
    }

    public void ToLine()
    {
        SceneManager.LoadScene("MagneticLine", LoadSceneMode.Single);
    }

    public void ToPaint()
    {
        SceneManager.LoadScene("MagneticPaint", LoadSceneMode.Single);
    }

    public void ToDraw()
    {
        SceneManager.LoadScene("MagneticDraw", LoadSceneMode.Single);
    }

}
