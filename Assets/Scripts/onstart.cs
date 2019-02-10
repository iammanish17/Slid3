using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onstart : MonoBehaviour {
    public Text l;
	// Use this for initialization
	void Start () {
        GameObject rx = GameObject.Find("pause button");
        GameObject con = Instantiate(rx, new Vector3((float)4.2, (float)-2.3, 0), transform.rotation);
        con.transform.localScale = new Vector3((float)0.941, (float)0.941, 1);
        l.text = "";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
