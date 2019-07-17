using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitIntroduce : MonoBehaviour {
    [SerializeField]
    private GameObject[] gms_text = new GameObject[6];   //6个三维字体
    [SerializeField]
    private Sprite[] intropic = new Sprite[7];       //7张介绍
    [SerializeField]
    private AudioClip[] introrai;   //7段音频

    public Image introimage;         //放介绍的背景
    public AudioSource introplay;    //放音频

	
	// Update is called once per frame
	void Update () {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)) {
            Physics.Raycast(ray, out hit);
            if (hit.collider != null)
            {
                {
                    for (int i = 0; i < 6; i++)
                    {
                        gms_text[i].GetComponent<MeshRenderer>().material.color = Color.white;          //字体颜色为白
                    }

                    hit.collider.GetComponent<MeshRenderer>().material.color = Color.red;               //用户选择的对象更改颜色

                    switch (hit.collider.tag)
                    {
                        case ("huaban"):      
                            introimage.sprite = intropic[1];
                            introplay.clip = introrai[1];
                            break;
                        case ("epian"):
                            introimage.sprite = intropic[2];
                            introplay.clip = introrai[2];
                            break;
                        case ("cirui"):
                            introimage.sprite = intropic[3];
                            introplay.clip = introrai[3];
                            break;
                        case ("xiongrui"):
                            introimage.sprite = intropic[4];
                            introplay.clip = introrai[4];
                            break;
                        case ("huabin"):
                            introimage.sprite = intropic[5];
                            introplay.clip = introrai[5];
                            break;
                        case ("huatuo"):
                            introimage.sprite = intropic[6];
                            introplay.clip = introrai[6];
                            break;
                        default:
                            break;

                    }
                }
            }
            //else
            //{
            //    for (int i = 0; i < 6; i++)
            //    {
            //        gms_text[i].GetComponent<MeshRenderer>().material.color = Color.white;          //字体颜色为白
            //    }
            //    introimage.sprite = intropic[0];
            //    introplay.clip = introrai[0];

            //}
        }
    }
}


