using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public Transform[] spawnPoints;

    public GameObject[] obstaclesPrefabs;

    public GameObject pickablePrefab;

    public GameObject obstacleHolder;

    public float timeBetweenSpawns=3f;

    [Range (1,100)]
    public int spawnProbability = 80;

    [Range(1, 100)]
    public int pickableSpawnProbability = 10;

    private int _numberOfSpawnPoints;
    private int _numberOfObstacles;
    private bool _spawnCoolDown=true;
    private float nextSpawnTime;
    private bool pickableNotOnCoolDown =true;

    private bool[] spawnChecker;
    // Start is called before the first frame update

    private void Awake()
    {
        _numberOfSpawnPoints = spawnPoints.Length;
        _numberOfObstacles = obstaclesPrefabs.Length;
        //InitObstacles();


    }

    void Start()
    {
    }
    /*
    private void InitObstacles()
    {
        for (int i = 0; i < _numberOfObstacles; i++)
        {
            for (int j = 0; j < numberOfDublicates; j++) {
                Debug.Log("obstacle " + obstaclesPrefabs[i].name + " initiated #" + j);
                obstacles[i, j] =(GameObject)Instantiate(obstaclesPrefabs[i],obstacleHolder.transform);
            }
        }
        currentObstacleDublicate = new int[_numberOfObstacles];
    }
    */
    private int PickNumberOfSpawns()
    {
        int num = Random.Range(1, 3);
        return num;
    }

    private void Spawn(int spawnLocation)
    {
        int pickableProb = Random.Range(1, 101);
        if(pickableProb <= pickableSpawnProbability && pickableNotOnCoolDown)
        {
            pickableNotOnCoolDown = false;

            GameObject pickable = Instantiate(pickablePrefab, obstacleHolder.transform);
            pickable.transform.position = spawnPoints[spawnLocation].position;
            Destroy(pickable, 20f);

            StartCoroutine(PickableCoolDownReset());
        }
        else
        {
            int obstacleNumber = Random.Range(0, _numberOfObstacles);
            Debug.Log("obstacle " + name + " spawned");
            GameObject obstacle = Instantiate(obstaclesPrefabs[obstacleNumber], obstacleHolder.transform);
            obstacle.transform.position = spawnPoints[spawnLocation].position;
            Destroy(obstacle, 20f);
        }
    }


    private void InitSpawn()
    {
            int numOfSpawns = PickNumberOfSpawns();
            spawnChecker = new bool[_numberOfSpawnPoints];
            for (int i = 0; i < numOfSpawns; i++)
            {
                int spawnPoint = Random.Range(0, _numberOfSpawnPoints);
                if (!spawnChecker[spawnPoint])
                {
                    spawnChecker[spawnPoint] = true;
                    Spawn(spawnPoint);
                }
            }
    }

    IEnumerator PickableCoolDownReset()
    {
        yield return new WaitForSeconds(1f);
        pickableNotOnCoolDown = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            int spawnProp = Random.Range(1, 101);
            if (spawnProp <= spawnProbability)
            {
                InitSpawn();
            }
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }
}
