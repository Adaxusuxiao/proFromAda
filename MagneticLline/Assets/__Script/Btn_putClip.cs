using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_putClip : MonoBehaviour {
    [SerializeField]
    private GameObject myClip, mydesk;
    private Vector3 placeClip;
    private float vx, vz;
    public int numOfClips = 10;            //产生的回形针数量；
    List<GameObject> ListClips = new List<GameObject>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Put_Clip()
    {
       // isField = true;
        mydesk.SetActive(true);
        foreach (GameObject i in ListClips)
        {
            Destroy(i);
        }
        ListClips.Clear();
        for (int i = 0; i < numOfClips; i++)
        {
            vx = Random.Range(-0.1f, 0.1f);
            vz = Random.Range(0.15f, 0.35f);
            placeClip = new Vector3(vx, 0f, vz);
            ListClips.Add(Instantiate(myClip, placeClip, Quaternion.Euler(-90, 0, 0)));


        }
    }
}
