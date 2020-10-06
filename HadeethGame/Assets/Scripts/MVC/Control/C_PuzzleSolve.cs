using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PuzzleSolve : MonoBehaviour
{
    public Transform[] puzzles;
    public Transform[] puzzleBases;
    public GameObject[] cameras;
    Transform[] bases;

    Vector3[] puzzlePositions;
    Transform[] randomPosition;
    bool[] posMap;

    int baseNum;

    int dificulty;

    int currentPuzzleSize;


    // Start is called before the first frame update
    void Start()
    {
        dificulty = GlobalVariables.puzzleDificulty;
        currentPuzzleSize = puzzles[dificulty - 1].childCount;
        InitBases();
        InitPuzzlePieces();
        RandomizePuzzle();
    }

    void InitPuzzlePieces()
    {
        puzzles[dificulty - 1].gameObject.SetActive(true);
        puzzleBases[dificulty - 1].gameObject.SetActive(true);
        cameras[dificulty - 1].SetActive(true);
        InitRandomPuzzles(currentPuzzleSize, dificulty - 1);
    }

    void InitRandomPuzzles(int puzzleSize,int dif)
    {
        posMap = new bool[puzzleSize];
        randomPosition = new Transform[puzzleSize];
        puzzlePositions = new Vector3[puzzleSize];
        int i = 0;
        foreach(Transform child in puzzles[dif])
        {
            puzzlePositions[i] = child.position;
            randomPosition[i++] = child;
            //Debug.Log(i + " x: " + child.position.x + " y: " + child.position.y + " z: " + child.position.z);
        }
    }

    void RandomizePuzzle()
    {
        int i = 0;
        int cnt = 0;
        while (i<currentPuzzleSize)
        {
            int rand = Random.Range(0, currentPuzzleSize);
            if (!posMap[rand]) {
                posMap[rand] = true;
                randomPosition[i].position = puzzlePositions[rand];
                i++;
            }
        }
    }

    void InitBases()
    {
        Transform basesParent = puzzleBases[dificulty-1];
        baseNum = basesParent.childCount;
        bases = new Transform[baseNum];
        int i = 0;
        foreach (Transform child in basesParent)
        {
            bases[i++] = child;
            Debug.Log(i + " x: " + child.position.x + " y: " + child.position.y + " z: " + child.position.z);
        }
    }

    public Transform CalculateDistances(Transform target,ref string place)
    {
        double minDist = 999999999;
        int minI = -1;
        for(int i = 0; i < baseNum; i++)
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
