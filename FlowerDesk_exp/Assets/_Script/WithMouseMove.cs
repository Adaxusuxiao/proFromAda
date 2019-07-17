using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class WithMouseMove : MonoBehaviour
{
    RaycastHit hit;
    private Transform Icon;
    public static bool gbIsMove = false;
 
    void Start()
    {
    }

    void Update()
    {
        Debug.Log(gbIsMove);
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if ((Physics.Raycast(ray, out hit, 500)) && (null != hit.collider))
            {
                Debug.Log("有物体跟随鼠标移动");
                gbIsMove = true;              //物体（镊子）移动时，teIsmovw=true
                Debug.DrawLine(ray.origin, hit.point);
                Icon = transform.GetComponent<Transform>();
                Vector3 screenPos = Camera.main.WorldToScreenPoint(Icon.position);
                Vector3 offset = Icon.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z));
                Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z);
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                Icon.position = worldPos;
            }
            else
            {
                gbIsMove = false;
                Debug.Log("没有物体跟随鼠标移动");
            }
           // gameObject.transform.GetComponent<Renderer>().material.color = Color.green;
  
           /* if (Input.GetKey(KeyCode.Delete))      /
            {
                Destroy(this.gameObject);
            }
            */
        }
    }
    void OnMouseDown()
    {
        Debug.Log(gbIsMove);
        gbIsMove = !gbIsMove;
    }

}
