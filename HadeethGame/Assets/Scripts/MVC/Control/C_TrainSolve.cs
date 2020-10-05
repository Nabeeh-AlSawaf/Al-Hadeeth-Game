using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_TrainSolve : MonoBehaviour
{
    public Transform cartsParent;
    public Transform couldsParent;

    public TrainManager trainManager;

    public GameObject cloudPrefab;

    private Transform[] clouds;
    private Transform[] cloudBases;
    Transform[] bases;

    Vector3[] cloudPositions;
    Transform[] randomPosition;
    bool[] posMap;

    int baseNum;

    int dificulty;

    int numberOfCarts;

    int currentPuzzleSize;


    // Start is called before the first frame update
    void Start()
    {
        
        numberOfCarts = trainManager.numberOfCarts;
        Debug.Log(numberOfCarts);
        
        dificulty = /*GlobalVariables.puzzleDificulty*/3;
        //currentPuzzleSize = clouds[dificulty - 1].childCount;

        InitBases();createClouds();
        /*InitPuzzlePieces();
        RandomizePuzzle();*/
    }


    void createClouds()
    {
        for (int i = 0; i < numberOfCarts; i++)
        {
            GameObject go = Instantiate(cloudPrefab, couldsParent);
            Debug.Log("inst");
            go.name = (i + 1).ToString();
            go.transform.position = new Vector3(bases[i].position.x, bases[i].position.y + 10, bases[i].position.z);
        }

    }
    void InitBases()
    {
        baseNum = cartsParent.childCount;
        Debug.Log("carts " + baseNum);
        bases = new Transform[baseNum];
        int i = 0;
        foreach (Transform child in cartsParent)
        {
            bases[i++] = child;
            Debug.Log(i + " x: " + child.position.x + " y: " + child.position.y + " z: " + child.position.z);
        }

    }

    void InitPuzzlePieces()
    {

        InitRandomPuzzles(currentPuzzleSize, dificulty - 1);
    }

    void InitRandomPuzzles(int puzzleSize, int dif)
    {
        posMap = new bool[puzzleSize];
        randomPosition = new Transform[puzzleSize];
        cloudPositions = new Vector3[puzzleSize];
        int i = 0;
        foreach (Transform child in clouds[dif])
        {
            cloudPositions[i] = child.position;
            randomPosition[i++] = child;
            //Debug.Log(i + " x: " + child.position.x + " y: " + child.position.y + " z: " + child.position.z);
        }
    }

    void RandomizePuzzle()
    {
        int i = 0;
        int cnt = 0;
        while (i < currentPuzzleSize)
        {
            int rand = Random.Range(0, currentPuzzleSize);
            if (!posMap[rand])
            {
                posMap[rand] = true;
                randomPosition[i].position = cloudPositions[rand];
                i++;
            }
        }
    }



    public Transform CalculateDistances(Transform target, ref string place)
    {
        double minDist = 999999999;
        int minI = -1;
        for (int i = 0; i < baseNum; i++)
        {
            double dist = Vector3.Distance(target.transform.position, bases[i].transform.position);
            if (dist <= 1f)
            {
                minDist = dist;
                minI = i;
            }
            //bases[i].GetChild(0).gameObject.SetActive(false);
        }
        if (minI != -1)
        {
            Debug.Log("closest is " + bases[minI].name);
            place = bases[minI].name;
            return bases[minI];
            bases[minI].GetChild(0).gameObject.SetActive(true);
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
