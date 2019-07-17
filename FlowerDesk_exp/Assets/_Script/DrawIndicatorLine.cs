using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawIndicatorLine : MonoBehaviour {
    private LineRenderer lineRenderer;
    private float width = 0.005f;
    private Color lineColor = Color.white;
    private int lineVertex = 2;

    [SerializeField]
    private GameObject flowerob, textob;


    // Use this for initialization
    void Start () {
        //判断是否有加控件
        if (GetComponent<LineRenderer>())
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
        else {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        //指示线属性
        lineRenderer.material =(Material)Resources.Load("linecolor/linecol");
        lineRenderer.alignment = LineAlignment.View;
        lineRenderer.positionCount = lineVertex;
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        lineRenderer.enabled = true;

    }
	
	// Update is called once per frame
	void Update () {
        Vector3[] linePoints = new Vector3[2];
        Vector3 tob = new Vector3();
        linePoints[0] = flowerob.transform.position;      //花的部位位置
        tob = linePoints[0];
        if (tob.x > 0)
        {
            tob.x = linePoints[0].x + 0.3f;
        }
        else
        {
            tob.x = linePoints[0].x - 0.3f;
        }
        if (tob.y > 0)
        {
            tob.y = linePoints[0].y + 0.2f;
        }
        else
        {
            tob.y = linePoints[0].y - 0.2f;
        }
        if (tob.z > 0)
        {
            tob.z = linePoints[0].z - 0.5f;
        }
        else
        {
            tob.z = linePoints[0].z + 0.5f;
        }
        textob.transform.position = tob;
        linePoints[1] = textob.transform.position;        //文字位置
        lineRenderer.SetPositions(linePoints);            //连线
	}
}
