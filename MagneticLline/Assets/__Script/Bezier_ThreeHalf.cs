using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier_ThreeHalf : MonoBehaviour {
    private LineRenderer lineRenderer,JtlineRenderer;     //定义
    private float startWidth = 0.001f;       //起始宽度
    private float endWidth = 0.001f;        //末尾宽度
    private Color lineColor = Color.green;    //颜色设置
    private int lineVertex = 20;         //线分割成几段
    public int lineDrawVertex = 8;
    // Use this for initialization

    public GameObject start0, end0, mstart, mend;
    float jianxi = 0.05f;              //绘制的0-1的间隙 越小曲线越接近曲线，  

    string startname;             //判断从哪一磁极出发
    bool Nstart;               // true，n极出发，false，s极出发

    //箭头
    public GameObject jt;
    private float startArrow = 0.003f;        //[0]大，[1]小
    private float endArrow = 0.001f;

    // Use this for initialization
    void Start()
    {
        if (GetComponent<LineRenderer>())      //磁感线
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
        else
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        if (jt.GetComponent<LineRenderer>())   //线上的箭头
        {
            JtlineRenderer = jt.GetComponent<LineRenderer>();
        }
        else {
            JtlineRenderer = jt.gameObject.AddComponent<LineRenderer>();
        }

        lineRenderer.enabled = false;  //先阻止其画线
        lineRenderer.alignment = LineAlignment.View;  //alignment：组件是否面向相机
                                                      //*****上述赋值
        lineRenderer.positionCount = lineDrawVertex;
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
        // lineRenderer.material = lineMat;
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;

        //箭头
        JtlineRenderer.startWidth = startArrow;   //0.003 从大变小
        JtlineRenderer.endWidth = endArrow;
        JtlineRenderer.alignment = LineAlignment.View;
        //
        startname = jt.name;
        if (startname.Contains("mn")) Nstart = true;      //靠近N极
        else Nstart = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] linePoints = new Vector3[lineDrawVertex];    //空间向量组，用于赋值
        Vector3[] arrowPoints = new Vector3[2];

        GetPoints(linePoints, arrowPoints);
        lineRenderer.enabled = true;
        lineRenderer.SetPositions(linePoints);
        JtlineRenderer.SetPositions(arrowPoints);
        //jt.GetComponent<LineRenderer>().SetPositions(arrowPoints);
    }

    void GetPoints(Vector3[] linePoints, Vector3[] arrowPoints)
    {
        float j = 0;
        Vector3 d;
        for (int i = 0; i < lineVertex; i++)
        {
            if (i < lineDrawVertex)
            {
                d = Po(j, start0, end0, mstart, mend);
                linePoints[i] = d;
                if (i == (lineDrawVertex -4))
                {
                    if (Nstart) arrowPoints[0] = d; else arrowPoints[1] = d;     //靠近N极，先大后小；
                }
                if (i == (lineDrawVertex -3))                                   //靠近S极，先小后大；
                {
                    if (Nstart) arrowPoints[1] = d; else arrowPoints[0] = d;
                }
            }
            j += jianxi;
        }      
    }
                 

    private Vector3 Po(float t, GameObject v0, GameObject v1, GameObject a0, GameObject a1)//根据当前时间t 返回路径  其中v0为起点 v1为终点 a为中间点  
    {
        Vector3 a;
        a.x = (1 - t) * (1 - t) * (1 - t) * v0.transform.position.x + 3 * (1 - t) * (1 - t) * t * a0.transform.position.x + 3 * (1 - t) * t * t * a1.transform.position.x + t * t * t * v1.transform.position.x;
        //公式为B(t)=(1-t)^3*P0 + 3*(1-t)^2*t*P1+ 3*(1-t)*t^2*P2 + t^3*P3   
        a.y = (1 - t) * (1 - t) * (1 - t) * v0.transform.position.y + 3 * (1 - t) * (1 - t) * t * a0.transform.position.y + 3 * (1 - t) * t * t * a1.transform.position.y + t * t * t * v1.transform.position.y;
        a.z = (1 - t) * (1 - t) * (1 - t) * v0.transform.position.z + 3 * (1 - t) * (1 - t) * t * a0.transform.position.z + 3 * (1 - t) * t * t * a1.transform.position.z + t * t * t * v1.transform.position.z; ;
        return a;
    }
}


