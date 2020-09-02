﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_EnviromentMoveView : MonoBehaviour
{

    public RoadManager roadManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("collision on Enviroment " + gameObject.name);

            roadManager.MoveEnviroment();
        }
    }
}