using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oxygen_O2 : MonoBehaviour {

    [SerializeField]
    private GameObject oxygenNormal;
    [SerializeField]
    private GameObject oxygenMic;
    [SerializeField]
    private GameObject[] oxygenAtom;
    [SerializeField]
    private int num_oxygen;


    public GameObject wallx1;
    public GameObject wallx2;
    public GameObject wallz1;
    public GameObject wallz2;
    private Vector3 wx1, nwx1;
    private Vector3 wx2, nwx2;
    private Vector3 wz1, nwz1;
    private Vector3 wz2, nwz2;

    public GameObject go_tempO2;


    // Use this for initialization
    void Start () {


        for (int i = 0; i < num_oxygen; i++)         //给予原子一个随机的初始运动方向
        {
            //oldpos = waterAtom.transform.position;
            float dx = Random.Range(-180f, 180f);
            float dy = Random.Range(-180f, 180f);
            float dz = Random.Range(-180f, 180f);
           // oxygenAtom[i].transform.rotation = Quaternion.Euler(dx, dy, dz);

        }

        //温度5℃时的运动范围
        Debug.Log(UIControl.val_temp_O2);
        nwx1 = wx1 = wallx1.transform.localPosition;
        nwx2 = wx2 = wallx2.transform.localPosition;
        nwz1 = wz1 = wallz1.transform.localPosition;
        nwz2 = wz2 = wallz2.transform.localPosition;


    }
	
	// Update is called once per frame
	void Update () {
        if (TrackableEvent_oxygen.getOxygen)
        {
            if (UIControl.isNormal)
            {
                oxygenNormal.SetActive(true);         //正常状态
                oxygenMic.SetActive(false);
              

            }
            else if (!UIControl.isNormal)
            {         //微观状态
                go_tempO2.SetActive(true);

                wallx1.transform.localPosition = Vector3.MoveTowards(nwx1, wx1 - new Vector3(0.002f * (UIControl.val_temp_O2 - 5), 0, 0), 1f * Time.deltaTime);
                wallx2.transform.localPosition = Vector3.MoveTowards(nwx2, wx2 + new Vector3(0.002f * (UIControl.val_temp_O2 - 5), 0, 0), 1f * Time.deltaTime);
                wallz1.transform.localPosition = Vector3.MoveTowards(nwz1, wz1 - new Vector3(0, 0, 0.002f * (UIControl.val_temp_O2 - 5)), 1f * Time.deltaTime);
                wallz2.transform.localPosition = Vector3.MoveTowards(nwz2, wz2 + new Vector3(0, 0, 0.002f * (UIControl.val_temp_O2 - 5)), 1f * Time.deltaTime);
                nwx1 = wallx1.transform.localPosition;
                nwx2 = wallx2.transform.localPosition;
                nwz1 = wallz1.transform.localPosition;
                nwz2 = wallz2.transform.localPosition;



                oxygenNormal.SetActive(false);
                oxygenMic.SetActive(true);
                for (int i = 0; i < num_oxygen; i++)
                {
                    oxygenAtom[i].transform.Translate(Vector3.forward * Time.deltaTime * UIControl.val_temp_O2 * 0.1f);
                }           

            }

        }
        else
        {
            oxygenNormal.SetActive(false);
            oxygenMic.SetActive(false);
            go_tempO2.SetActive(false);
        }

    }
}
