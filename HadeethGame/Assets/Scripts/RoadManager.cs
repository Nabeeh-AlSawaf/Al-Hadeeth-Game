using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [Header("Put in the correct order in the scene")]
    public Transform[] enviroments;
    [Header("Put in the correct order in the scene")]
    public Transform[] roads;

    public float roadLength;
    public float enviromentLength;

    private Transform [] enviromentsRandomHolders;

    private int currentRoad = 0;
    private int currentEnviroment = 0;
    // Start is called before the first frame update
    void Start()
    {
        int envlen = enviroments.Length;
        enviromentsRandomHolders = new Transform[envlen];
        for (int i = 0; i < envlen; i++)
        {
            enviromentsRandomHolders[i] = enviroments[i].GetChild(1);//the random holders have to be the second object in the enviroment
            InitNextEnviroment();
            currentEnviroment++;
        }
        currentEnviroment = 0;
    }

    public void MoveRoad()
    {
        roads[currentRoad].position =new Vector3(roads[currentRoad].position.x, roads[currentRoad].position.y, roads[currentRoad].position.z+ roadLength);
        currentRoad = (currentRoad + 1) % roads.Length;
    }
    
    private void InitNextEnviroment()
    {
        foreach(Transform child in enviromentsRandomHolders[currentEnviroment])
        {
            int numberOfChildren = child.childCount;
            foreach(Transform obj in child)
            {
                obj.gameObject.SetActive(false);
            }
            int rand = Random.Range(-1, numberOfChildren);
            Debug.Log("child name is " + child.name + " rand is " + rand);
            if (rand >= 0)
                child.GetChild(rand).gameObject.SetActive(true);
        }
    }

    public void MoveEnviroment()
    {
        enviroments[currentEnviroment].position = new Vector3(enviroments[currentEnviroment].position.x, 
            enviroments[currentEnviroment].position.y, enviroments[currentEnviroment].position.z + enviromentLength);
        InitNextEnviroment();
        currentEnviroment = (currentEnviroment + 1) % enviroments.Length;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
