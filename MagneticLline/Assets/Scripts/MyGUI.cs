using UnityEngine;
using System.Collections;

public class MyGUI : MonoBehaviour
{

    //定义菜单项贴图  
    public Texture start;
    public Texture exit;

    //定义标准屏幕分辨率  
    public float m_fScreenWidth = 1280;
    public float m_fScreenHeight = 800;

    //定义缩放系数  
    public float m_fScaleWidth;
    public float m_fScaleHeight;

    void Update()
    {

        //计算缩放系数  
        m_fScaleWidth = (float)Screen.width / m_fScreenWidth;
        m_fScaleHeight = (float)Screen.height / m_fScreenHeight;
    }

    void OnGUI()
    {
        //绘制菜单  
        GUI.Button(new Rect(10 * m_fScaleWidth, 10 * m_fScaleHeight, 200 * m_fScaleWidth, 50 * m_fScaleHeight), start);
        GUI.Button(new Rect(814 * m_fScaleWidth, 708 * m_fScaleHeight, 200 * m_fScaleWidth, 50 * m_fScaleHeight), exit);
    }
}