using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PuzzleSolve : MonoBehaviour
{
    Transform[] Bases;

    int baseNum;

    // Start is called before the first frame update
    void Start()
    {
        initBases();
    }

    void initBases()
    {
        Transform basesParent = GameObject.Find("PuzzleBase").GetComponent<Transform>();
        baseNum = basesParent.childCount;
        Bases = new Transform[baseNum];
        int i = 0;
        foreach (Transform child in basesParent)
        {
            Bases[i++] = child;
            Debug.Log(i + " x: " + child.position.x + " y: " + child.position.y + " z: " + child.position.z);
        }
    }

    public Transform CalculateDistances(Transform target,ref string place)
    {
        double minDist = 999999999;
        int minI = -1;
        for(int i = 0; i < baseNum; i++)
        {
            double dist = Vector3.Distance(target.transform.position, Bases[i].transform.position);
            if (dist <= 1f)
            {
                minDist = dist;
                minI = i;
            }
            Bases[i].GetChild(0).gameObject.SetActive(false);
        }
        if (minI != -1)
        {
            Debug.Log("closest is " + Bases[minI].name);
            place = Bases[minI].name;
            return Bases[minI];
            Bases[minI].GetChild(0).gameObject.SetActive(true);
        }
        else
            Debug.Log("closest is none");
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
