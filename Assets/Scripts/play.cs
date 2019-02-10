using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class play : MonoBehaviour
{
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
        l.text = "";
        GameObject[] p = GameObject.FindGameObjectsWithTag("paused");
        foreach (GameObject go in p)
        {
            if (go.transform.position == new Vector3((float)-0.384, (float)-0.071, 0))
                Destroy(go);
        }
        GameObject[] q = GameObject.FindGameObjectsWithTag("buttons");
        foreach (GameObject go in q)
        {
            if (go.transform.position == new Vector3((float)-0.6, (float)0.22, 0))
                Destroy(go);
            if (go.transform.position == new Vector3((float)-0.6, (float)-1, 0))
                Destroy(go);
            if (go.transform.position == new Vector3((float)4.2, (float)2.4, 0))
                Destroy(go);
        }
        GameObject[] r = GameObject.FindGameObjectsWithTag("pb");
        foreach (GameObject go in r)
        {
            GameObject m = Instantiate(go, new Vector3((float)4.2, (float)-2.3, 0), transform.rotation);
            m.transform.localScale = new Vector3((float)0.941, (float)0.941, 0);
        }
    }
}