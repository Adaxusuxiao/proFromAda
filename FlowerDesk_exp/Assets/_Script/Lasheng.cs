using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lasheng : MonoBehaviour {
   // public GameObject gblahuan;
   // public GameObject gbguding;
   // public GameObject gbend;
   // public GameObject huabantest;

   // private Vector3 gblhstart;     //拉环的开始位置
   // private Vector3 gblhend;       //拉环最远位置
   // private Vector3 gblh;          //拉环当前位置

   // private float dgb;    //拉环和固定点的距离

    //private Vector3 gbhuabanstart;
    //private Vector3 gbhuaban;

    [SerializeField]
    private GameObject[] gb = new GameObject[17];    //17个要拆分的对象

    private Vector3[] gbstart = new Vector3[17];        //17个对象的初始位置
    private Vector3[] gbmove = new Vector3[17];
    private Vector3[] gbnow = new Vector3[17];

    // Use this for initialization
    void Start () {
        //gblhstart = gblahuan.GetComponent<Transform>().position;
        //gbhuabanstart = huabantest.GetComponent<Transform>().localPosition;

        for (int i = 0; i < 17; i++)
        {
            gbstart[i] = gb[i].GetComponent<Transform>().localPosition;
        }

        getMovedis(gbmove);

    }

    public void TaohuaLasheng(Slider slider)
    {         
            float d = slider.value;
            for (int k = 0; k < 17; k++)
                {
                    gbnow[k].x = gbstart[k].x + gbmove[k].x * (d);
                    gbnow[k].y = gbstart[k].y + gbmove[k].y * (d);
                    gbnow[k].z = gbstart[k].z - gbmove[k].z * (d);
                    gb[k].GetComponent<Transform>().localPosition = gbnow[k];
                }
    }

    private void getMovedis(Vector3[] gbmove) {
        gbmove[0].Set(0f, -0.02f, 0f);       //花瓣与花托
        gbmove[1].Set(0.033f, 0.024f, -0.0046f);       //花瓣1
        gbmove[2].Set(0.001f, 0.024f, 0.04f);       //花瓣2
        gbmove[3].Set(-0.03f, 0.03f, -0.01f);       //花瓣3
        gbmove[4].Set(-0.006f, 0.02f, -0.017f);       //花瓣4
        gbmove[5].Set(0.015f, 0.02f, -0.025f);       //花瓣5
        gbmove[6].Set(0.006f, -0.007f, -0.015f);       //萼片1
        gbmove[7].Set(0.01f, 0f, -0.01f);       //萼片2
        gbmove[8].Set(-0.012f, 0f, 0.01f);       //萼片3
        gbmove[9].Set(-0.013f, -0.0025f, 0f);       //萼片4
        gbmove[10].Set(0.007f, -0.012f, -0.02f);       //萼片5
        gbmove[11].Set(0f, 0.02f, 0.01f);       //雄蕊1
        gbmove[12].Set(0.01f, 0.02f,0.001f);       //雄蕊2
        gbmove[13].Set(-0.02f, 0.02f, -0.007f);       //雄蕊3
        gbmove[14].Set(0.005f, 0.02f, -0.015f);       //雄蕊4
        gbmove[15].Set(0.0047f, 0.02f, 0.014f);       //雄蕊5
        gbmove[16].Set(0f, 0.005f, 0f);       //雌蕊

    }

    /*  void Update () {
      if (WithMouseMove.gbIsMove == false)            //桃花不移动
      {
          if (gblahuan.GetComponent<Transform>().position.y > gbend.GetComponent<Transform>().position.y)
          {
              gblahuan.GetComponent<Transform>().position = gblhstart;

              for (int j = 0; j < 17; j++)
              {
                  gb[j].GetComponent<Transform>().localPosition = gbstart[j];
              }
          }
      }
      else
      {
          dgb = Vector3.Distance(gbguding.GetComponent<Transform>().position, gblahuan.GetComponent<Transform>().position);
          Debug.Log(dgb);
          if (0.2 < dgb && dgb < 0.5)
          {
              for (int k = 0; k < 17; k++)
              {
                  gbnow[k].x = gbstart[k].x + gbmove[k].x * ((dgb - 0.2f) / 0.3f);
                  gbnow[k].y = gbstart[k].y + gbmove[k].y * ((dgb - 0.2f) / 0.3f);
                  gbnow[k].z = gbstart[k].z - gbmove[k].z * ((dgb - 0.2f) / 0.3f);
                  gb[k].GetComponent<Transform>().localPosition = gbnow[k];
              }
          }

      }
  }
*/
}
