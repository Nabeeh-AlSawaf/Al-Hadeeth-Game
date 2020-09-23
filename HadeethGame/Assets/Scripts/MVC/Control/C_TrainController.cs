using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_TrainController : MonoBehaviour
{
    public GameObject cameraPivot;
    public float trainSpeed=20f;

    //public float sensitivity=1f;

    private float mouseX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void MoveForward()
    {
        transform.Translate(transform.forward * -trainSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        /*
        if (Input.GetMouseButton(0))
        {
            mouseX = Input.GetAxis("Mouse X");
            cameraPivot.transform.position += transform.forward * (mouseX * -1) * sensitivity;
        }*/
    }
}
