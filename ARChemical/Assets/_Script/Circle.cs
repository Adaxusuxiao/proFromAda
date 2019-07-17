using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Circle
{
    public float xAxis;
    public float yAxis;

    public Circle(float xAxis, float yAxis)
    {
        this.xAxis = xAxis;
        this.yAxis = yAxis;
    }
    public Vector2 Evaluate(float t)
    {
        float angle = Mathf.Deg2Rad * 360f * t;
        float x = Mathf.Sin(angle) * xAxis;
        float y = Mathf.Cos(angle) * yAxis;
        return new Vector2(x, y);
    }
}
