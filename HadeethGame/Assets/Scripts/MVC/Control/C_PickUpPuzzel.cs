using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PickUpPuzzel : MonoBehaviour
{
    //public float forceAmount = 3;

    public C_PuzzleSolve puzzleSolver;

    string currentPuzzle="";

    string pickedArea = "";

    Transform solve;

    Transform puzzleClick;

    Vector3 basePuzzlePosition;

    Transform selectedPuzzle;
    Camera targetCamera;

    Animator objectAn;
    

    

    // Start is called before the first frame update
    void Start()
    {
        targetCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (!targetCamera)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            //Check if we are hovering over Rigidbody, if so, select it
            puzzleClick = GetPuzzelTransformFromMouseClick();

            if (puzzleClick)
            {            
                basePuzzlePosition = puzzleClick.parent.position;
                currentPuzzle = puzzleClick.parent.name;
                selectedPuzzle = puzzleClick.parent;
                Debug.Log("selected transform" + selectedPuzzle.name);
                objectAn = selectedPuzzle.GetComponent<Animator>();
                objectAn.SetTrigger("GoUp");
            }
            
        }
        if (Input.GetMouseButtonUp(0) && selectedPuzzle)
        {
            //Release selected Rigidbody if there any
            if (puzzleClick)
            {
                Debug.Log(currentPuzzle + " " + pickedArea);
                
                if (solve&&currentPuzzle.Equals(pickedArea))
                {
                    selectedPuzzle.position = solve.position;
                }
                else
                {
                    Debug.Log("reset to base!!");
                    selectedPuzzle.position = basePuzzlePosition;
                }

                selectedPuzzle = null;
                objectAn.SetTrigger("GoDown");
                puzzleClick = null;
                basePuzzlePosition = new Vector3();
            }

        }
    }

    void FixedUpdate()
    {
        if (selectedPuzzle)
        {
            float planeY = 0;
            Transform draggingObject = selectedPuzzle.transform;

            Plane plane = new Plane(Vector3.up, Vector3.up * planeY); // ground plane

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float distance; // the distance from the ray origin to the ray intersection of the plane
            if (plane.Raycast(ray, out distance))
            {
                draggingObject.position = new Vector3(ray.GetPoint(distance).x, draggingObject.position.y, ray.GetPoint(distance).z); // distance along the ray
            }
            solve = puzzleSolver.CalculateDistances(draggingObject,ref pickedArea);
        }
    }

    Transform GetPuzzelTransformFromMouseClick()
    {
        RaycastHit hitInfo = new RaycastHit();
        Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);
        bool hit = Physics.Raycast(ray, out hitInfo,100);
        Debug.DrawRay(ray.origin, hitInfo.point,Color.green);
        if (hit)
        {
            if (hitInfo.collider.gameObject.GetComponentInParent<Transform>())
            {
                return hitInfo.collider.gameObject.GetComponentInParent<Transform>();
            }
        }

        return null;
    }


}
