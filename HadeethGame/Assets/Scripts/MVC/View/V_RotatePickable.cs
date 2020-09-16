using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_RotatePickable : MonoBehaviour
{

    public float rotationSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        float rand = Random.Range(0, 361);
        Vector3 v = new Vector3(0,rand,0);
        transform.eulerAngles = v;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));

    }
}
