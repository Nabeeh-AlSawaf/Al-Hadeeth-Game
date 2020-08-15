using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_CameraPositioning : MonoBehaviour
{

    public Transform[] basePositions;
    public Transform playerPosition;
    public int dissposition = 10;
    public float zoomValue=1.2f;

    private int currentLevel=0;

    Vector3 CalculateCameraPosition(Vector3 basePosition,Vector3 playerPosition)
    {
        Vector3 avgPosition = (basePosition + playerPosition) / 2;
        avgPosition *= zoomValue;
        avgPosition.z -= dissposition;

        return avgPosition;
    }

    void MoveCameraPosition(Vector3 move)
    {
        this.transform.position = move;

    }

    public void MoveUpALevel()
    {
        currentLevel++;
    }

    public void MoveDownALevel()
    {
        currentLevel--;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 calculatedPosition = CalculateCameraPosition(basePositions[currentLevel].position, playerPosition.position);
        MoveCameraPosition(calculatedPosition);
    }
}
