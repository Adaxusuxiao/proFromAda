using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Btn_ChangeView : MonoBehaviour {
    public GameObject btn_ChangeView;
    public Sprite PicAdd;            //点击变大，目前是小；
    public Sprite PicSmall;           //点击变小，目前是大；
    public GameObject panel_view;    //全面图，小图
    public GameObject scroll_view;   //滚轮图，大图

    Button btn;
    private bool isLarge;

	// Use this for initialization
	void Start () {
        btn = btn_ChangeView.GetComponent<Button>();
        isLarge = false;        //目前是小图
        btn.GetComponent<Image>().sprite = PicAdd;
        panel_view.SetActive(true);
        scroll_view.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeView(){
        if (isLarge)
        {            //目前是大图,要变小图
            btn.GetComponent<Image>().sprite = PicAdd;
            panel_view.SetActive(true);
            scroll_view.SetActive(false);
            isLarge = false;
        }
        else {           //目前是小图，要变大图
            btn.GetComponent<Image>().sprite = PicSmall;
            panel_view.SetActive(false);
            scroll_view.SetActive(true);
            isLarge = true;

        }


    }
}
