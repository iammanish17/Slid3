using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    public GameObject k1, k2, k3;
    public Text l;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        GameObject[] pb = GameObject.FindGameObjectsWithTag("pb");
        foreach (GameObject pc in pb)
        {
            if (pc.transform.position == new Vector3((float)4.2, (float)-2.3, 0))
            {
                Destroy(pc);
            }
        }
        GameObject[] p = GameObject.FindGameObjectsWithTag("paused");
        GameObject p1 = Instantiate(p[0], new Vector3((float)-0.384, (float)-0.071, 0), transform.rotation);
        p1.transform.localScale = new Vector3((float)0.6337805, (float)1.190305, 1);
        l.text = "Paused";
        Instantiate(k1, new Vector3((float)-0.6, (float)0.22, 0), transform.rotation);
        Instantiate(k2, new Vector3((float)-0.6, (float)-1, 0), transform.rotation);
        Instantiate(k3, new Vector3((float)4.2, (float)2.4, 0), transform.rotation);


    }

}