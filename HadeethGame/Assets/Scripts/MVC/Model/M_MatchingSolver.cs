using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_MatchingSolver : MonoBehaviour
{
    public Transform startwords;
    public Transform endwords;
    public static Vector3[] originalPositions;
    Transform[] baseObjects;
    bool[] posMap;

    // Start is called before the first frame update
    void Start()
    {
        C_MatchingSolver.MatchWords.Clear();
        C_MatchingSolver.MatchNames.Clear();
        initEnds();
        initNames();
    }
    public void initMatching()
    {
        foreach (Transform child in startwords)
        {
            child.tag = "Startwords";
        }
        C_MatchingSolver.MatchWords.Clear();
        initEnds();
        StartCoroutine(WaitForInitialize(1f));
    }

    //NO USE FOR NOW
    IEnumerator WaitForInitialize(float time)
    {

        //yield on a new YieldInstruction that waits for time seconds.
        yield return new WaitForSeconds(time);

        //After we have waited  seconds print the time again.

        foreach (Transform child in startwords)
        {
            child.GetChild(0).GetChild(0).gameObject.SetActive(false);
        }
        foreach (Transform child in endwords)
        {
            child.GetChild(0).GetChild(0).gameObject.SetActive(false);
        }
    }


    public void AnimateAll()
    {
        foreach (Transform child in startwords)
        {
            child.GetChild(0).GetComponent<Animator>().SetTrigger("Start");

            child.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }
        foreach (Transform child in endwords)
        {
            child.GetChild(0).GetComponent<Animator>().SetTrigger("Start");
            child.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }
    }

    public void initNames()
    {
        for(int i =0;i< startwords.childCount; i++)
        {
            C_MatchingSolver.MatchNames.Add(startwords.GetChild(i).name, endwords.GetChild(i).name);
        }
    }

    public void initEnds()
    {
        var baseNum = endwords.childCount;
        originalPositions = new Vector3[baseNum];
        posMap = new bool[baseNum];
        baseObjects = new Transform[baseNum];
        int i = 0;
        foreach (Transform child in endwords)
        {
            originalPositions[i] = child.position;
            baseObjects[i++] = child;

      //      Debug.Log(i + " x: " + child.position.x + " y: " + child.position.y + " z: " + child.position.z);
        }

         i = 0;
        while (i < baseNum)
        {
            int rand = Random.Range(0, baseNum);
            if (!posMap[rand])
            {
                posMap[rand] = true;
                baseObjects[i].position = originalPositions[rand];
                C_MatchingSolver.MatchWords.Add(baseObjects[i].name, baseObjects[i].position);
                i++;
            }
        }
    }
}
