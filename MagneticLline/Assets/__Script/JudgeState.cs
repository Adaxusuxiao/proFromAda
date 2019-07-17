using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JudgeState : MonoBehaviour {
    public int MagnetState;

    //判断哪些磁铁被识别
    [SerializeField]
    private GameObject MagLine_Bar1, MagLine_Bar2, MagLine_U;
    private bool mlb1, mlb2, mlu;
    // Use this for initialization

    //判断磁铁间的距离，处于相吸/排斥的状态
    [SerializeField]
    private GameObject BarS1, BarN1, BarS2, BarN2;
    private Vector3 v1s, v1n, v2s, v2n;
    private Vector3 vb1sr, vb2sr,vb1nr, vb2nr;
    float d1s2s, d1s2n, d1n2s, d1n2n;

    [SerializeField]
    private GameObject B1SA, B1SR, B2SA, B2SR, B1NA, B1NR, B2NA, B2NR;

    void Start () {
        vb1sr = B1SR.transform.localPosition;
        vb2sr = B2SR.transform.localPosition;
        vb1nr = B1NR.transform.localPosition;
        vb2nr = B2NR.transform.localPosition;
    }
    // Update is called once per frame
    void Update()
    { 
            Judge_State();
    }


    void Judge_State() {
    mlb1 = TrackableEvent_Bar1.trackBar1;   // 条形磁铁1 被追踪
    mlb2 = TrackableEvent_Bar2.trackBar2;   // 条形磁铁2 被追踪
    mlu = TrackableEvent_U.trackU;      //  U型磁铁  被追踪

    if (mlb1 && mlb2)                //两个条形磁铁被扫描，不画周围一圈磁感线； 对两者位置进行判断。
    {
        MagLine_Bar1.SetActive(false);
        MagLine_Bar2.SetActive(false);
        MagLine_U.SetActive(false);
        //S1\S2都被识别
        BarS1.SetActive(true);
        BarS2.SetActive(true);
        BarN1.SetActive(true);
        BarN2.SetActive(true);
        Judge_ifAttract();
    }
    else
    {
        BarS1.SetActive(false);
        BarS2.SetActive(false);
        BarN1.SetActive(false);
        BarN2.SetActive(false);

        if ((mlu && (mlb1 || mlb2)) || !(mlb1 || mlb2 || mlu))    //U和s1、s2同时出现或都不出现时，不绘制磁感线；
        {
            MagLine_Bar1.SetActive(false);
            MagLine_Bar2.SetActive(false);
            MagLine_U.SetActive(false);
        }
        else if (mlu && !(mlb1 || mlb2))                         //U出现，其他两者不出现，画U的磁感线
        {
            MagLine_Bar1.SetActive(false);
            MagLine_Bar2.SetActive(false);
            MagLine_U.SetActive(true);
        }
        else if (mlb1 && !(mlu || mlb2))                         //条形磁铁1出现，其他两者不出现，画Bar1的磁感线
        {
            MagLine_Bar1.SetActive(true);
            MagLine_Bar2.SetActive(false);
            MagLine_U.SetActive(false);
        }
        else
        {                                                       //条形磁铁2出现，其他两者不出现，画Bar2的磁感线
            MagLine_Bar1.SetActive(false);
            MagLine_Bar2.SetActive(true);
            MagLine_U.SetActive(false);
        }
        }
    }

    void Judge_ifAttract() {                      //判断
        v1s = BarS1.transform.position;
        v1n = BarN1.transform.position;
        v2s = BarS2.transform.position;
        v2n = BarN2.transform.position; 
        d1s2s = Vector3.Distance(v1s, v2s);        //B1S和B2S相互排斥
        d1s2n = Vector3.Distance(v1s, v2n);        //B1S和B2N相吸
        d1n2n = Vector3.Distance(v1n, v2n);        //B1N和B2N相互排斥
        d1n2s = Vector3.Distance(v1n, v2s);        //B1N和B2S相吸

        if (((d1n2s < d1n2n) && (d1n2s < d1s2s) && (d1n2s < d1s2n)))          //磁铁1的N极和磁铁2的S极接近，相互吸引状态；
        {
            B1SA.SetActive(false);
            B2NA.SetActive(false);
            B1NR.SetActive(false);
            B1SR.SetActive(false);
            B2NR.SetActive(false);
            B2SR.SetActive(false);
            Debug.Log(d1n2s);
            if ((d1n2s > 0.01) && (d1n2s < 0.060)) {                        //当接近在一定距离内，绘制两者之间的磁感线       
            B1NA.SetActive(true);
            B2SA.SetActive(true);   //1n2s
            }
            else
            {
                B1NA.SetActive(false);
                B2SA.SetActive(false);
            }
        }
        else if (((d1s2n < d1n2n) && (d1s2n< d1s2s) && (d1s2n< d1n2s)))        //磁铁1的S极和磁铁2的N极接近，同相互吸引状态；
        {
            B1NA.SetActive(false);
            B2SA.SetActive(false);
            B1NR.SetActive(false);
            B1SR.SetActive(false);
            B2NR.SetActive(false);
            B2SR.SetActive(false);
            if ((d1s2n > 0.01) && (d1s2n < 0.06))
            {
                B1SA.SetActive(true);
                B2NA.SetActive(true);
            }
            else
            {
                B1SA.SetActive(false);
                B2NA.SetActive(false);
            }
        }
        else if ((d1n2n<d1s2s))                                   //磁铁1的N极和磁铁2的N极接近，相互排斥状态；
        {
            if ((d1n2n > 0.013) && (d1n2n < 0.08))
            {
                B1NR.SetActive(true);
                B2NR.SetActive(true);
                if (d1n2n < 0.04) {
                    var v1 = B1NR.transform.localPosition;
                    var v2 = B2NR.transform.localPosition;
                    v1.y= vb1nr.y- ((0.04f - d1n2n) * 0.2f) / 0.027f;
                    v2.y =vb2nr.y- ((0.04f - d1n2n) * 0.2f) / 0.027f;
                    B1NR.transform.localPosition = v1;
                    B2NR.transform.localPosition = v2;
                }
            }
            else
            {
                B1NR.SetActive(false);
                B2NR.SetActive(false);
            }
            B1NA.SetActive(false);
            B2SA.SetActive(false);   
            B1SA.SetActive(false);
            B2NA.SetActive(false);
            B1SR.SetActive(false);          
            B2SR.SetActive(false);
         
            Debug.Log(Vector3.Distance(B2NR.transform.position, B1NR.transform.position));
        }
        else                                            //磁铁1的S极和磁铁2的S极接近，相互排斥状态；
        {
            if ((d1s2s > 0.013) && (d1s2s < 0.08))
            {
                B1SR.SetActive(true);
                B2SR.SetActive(true);
                if (d1s2s < 0.04)
                {
                    var v1 = B1SR.transform.localPosition;
                    var v2 = B2SR.transform.localPosition;
                    v1.y = vb1sr.y + ((0.04f - d1s2s) * 0.2f) / 0.028f;
                    v2.y = vb2sr.y + ((0.04f - d1s2s) * 0.2f) / 0.028f;
                    B1SR.transform.localPosition = v1;
                    B2SR.transform.localPosition = v2;
                }
            }
            else
            {
                B1SR.SetActive(false);
                B2SR.SetActive(false);
            }
            B1NA.SetActive(false);
            B2SA.SetActive(false);   
            B1SA.SetActive(false);
            B2NA.SetActive(false);
            B1NR.SetActive(false);
            B2NR.SetActive(false);
            Debug.Log("***"+d1s2s);
            Debug.Log(Vector3.Distance(B2SR.transform.position, B1SR.transform.position));
        }
    }
}


