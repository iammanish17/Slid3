using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onreset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        PlayerPrefs.DeleteKey("Won");
        PlayerPrefs.DeleteKey("TotalMoves");
        PlayerPrefs.DeleteKey("TotalTime");
        PlayerPrefs.DeleteKey("BestMoves");
        PlayerPrefs.DeleteKey("BestTime");
    }
}
