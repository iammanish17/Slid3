using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    // Use this for initialization
    public List<GameObject> spawnPositions;
    public List<GameObject> spawnObjects;
    public GameObject one, two;

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        int[] numlist = new int[15];
        int k = 0;
        foreach (GameObject spawnPosition in spawnPositions)
        {
            int selection = UnityEngine.Random.Range(0, spawnObjects.Count);
            GameObject g = Instantiate(spawnObjects[selection], spawnPosition.transform.position, spawnPosition.transform.rotation);
            g.transform.localScale = new Vector3((float)1.7, (float)1.7, 0);
            numlist[k] = Int32.Parse(g.name.Replace(" (1)", "").Replace("(Clone)", ""));
            spawnObjects.RemoveAt(selection);
            if (k == 0) one = g;
            if (k == 1) two = g;
            k += 1;
        }
        int count = 0;
        for(int i=0; i<=13; i++)
        {
            for(int j=i+1; j<=14; j++)
            {
                if (numlist[j] < numlist[i])
                    count += 1;
            }
        }
        if (count % 2 == 1)
        {
            Vector3 tempos = one.transform.position;
            one.transform.position = two.transform.position;
            two.transform.position = tempos;

        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
