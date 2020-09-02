using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_CarController : MonoBehaviour
{
    

    [Header("0->Left 1->Middle 2->Right")]
    public Transform[] carPositions = new Transform[3];

    public float carSpeed = 6f;

    public float straifSpeed = 20f;

    private int currentPosition = 1;

    private Transform carObject;
    private Transform moveToPosition;
    private bool moveTo;
    private int nextMove;

    void Start()
    {
        carObject = gameObject.transform.Find("Car_FBX");
    }


    private void MoveForward()
    {
        transform.Translate(transform.forward * carSpeed * Time.deltaTime);

    }

    private bool CheckMovement(int move)//1 is right -1 is left
    {
        if (currentPosition + move <= 2 && currentPosition + move >= 0) return true;
        return false;
    }

    private void MoveToPosition()
    {
        if (moveTo)
        {
            carObject.transform.position =  Vector3.MoveTowards(carObject.transform.position, moveToPosition.transform.position, straifSpeed * Time.deltaTime);
            float distance = Vector3.Distance(carObject.transform.position,moveToPosition.transform.position) ;
           // Debug.Log("distance is " + distance);
            if (distance <= 0.001f)
            {
                moveTo = false;
                currentPosition = nextMove;
            }
        }
    }

    private void KeyBoardTest()
    {
        if (Input.GetKeyDown(KeyCode.D)) MoveRight();
        if (Input.GetKeyDown(KeyCode.A)) MoveLeft();
    }

    public void MoveRight()
    {
        int moveRight = 1;
        if (CheckMovement(moveRight))
        {
            nextMove = currentPosition + moveRight;
            moveToPosition = carPositions[nextMove];
            moveTo = true;
        }
    }

    public void MoveLeft()
    {
        int moveLeft = -1;
        if (CheckMovement(moveLeft))
        {
            nextMove = currentPosition + moveLeft;
            moveToPosition = carPositions[nextMove];
            moveTo = true;
        }
    }

    private void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        MoveToPosition();
        KeyBoardTest();
    }
}
