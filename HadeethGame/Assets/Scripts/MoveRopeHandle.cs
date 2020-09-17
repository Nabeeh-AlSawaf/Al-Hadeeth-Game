using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRopeHandle : MonoBehaviour
{
    public float forceAmount = 3;

    public C_MatchingSolver CmatchingSolver;
    public M_MatchingSolver MmatchingSolver;


    public GameObject ropePrefab;
    List<GameObject> AllRopes = new List<GameObject>();
    string currentPuzzle = "";

    string solve;
    int solves = 0;

    Transform puzzleClick, StartOBJ;

    Vector3 basePuzzlePosition;

    Transform selectedPuzzle;
    Camera targetCamera;

  //  Animator objectAn;




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
            puzzleClick = GetPuzzelTransformFromMouseClick(out StartOBJ);

            if (puzzleClick)
            {
                basePuzzlePosition = puzzleClick.position;
              //  currentPuzzle = puzzleClick.name;
                selectedPuzzle = puzzleClick;
                Debug.Log("selected transform" + selectedPuzzle.name);
           //     objectAn = selectedPuzzle.GetComponent<Animator>();
           //     objectAn.SetTrigger("GoUp");
            }

        }
        if (Input.GetMouseButtonUp(0) && selectedPuzzle!=null)
        {
            //Release selected Rigidbody if there any
            if (puzzleClick)
            {
            //    Debug.Log(currentPuzzle + "  sdadah   asd  " + solve);
                if (currentPuzzle != null && solve !=null  && currentPuzzle.Equals(solve))
                {
                    //needs processing
                    Vector3 pos = new Vector3();
                    if (CmatchingSolver.getMatchingPosition(solve, out pos))
                    { 
                        selectedPuzzle.position = pos;
                        Destroy(selectedPuzzle.parent.GetChild(0).GetComponent<Obi.ObiSolver>(),1f);
                        StartOBJ.tag = "NOTAG";
                        solves++;
                        NextPortion();
                    }

                }
                else
                {
                //    Debug.Log("reset to base!!");
                    selectedPuzzle.position = basePuzzlePosition;
                    Destroy(selectedPuzzle.parent.gameObject, 1f);
                }

                selectedPuzzle = null;
              //  objectAn.SetTrigger("GoDown");
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

            Plane plane = new Plane(Vector3.forward, Vector3.forward * planeY); // ground plane

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float distance; // the distance from the ray origin to the ray intersection of the plane
            if (plane.Raycast(ray, out distance))
            {
                draggingObject.position = new Vector3(ray.GetPoint(distance).x, ray.GetPoint(distance).y, draggingObject.position.z); // distance along the ray

            }
            solve = MatchingSolver.currentMatch;
        }
    }

    public void NextPortion()
    {
        if (solves >= 4)
        {
            MmatchingSolver.AnimateAll();
            foreach (var obj in AllRopes)
            {
                Destroy(obj);
            }
            AllRopes.Clear();
            MmatchingSolver.initMatching();
            solves = 0;
        }
    }
    Transform GetPuzzelTransformFromMouseClick(out Transform startobj)
    {
        RaycastHit hitInfo = new RaycastHit();
        Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);
        bool hit = Physics.Raycast(ray, out hitInfo, 100);
        Debug.DrawRay(ray.origin, hitInfo.point, Color.green);
        if (hit)
        {
            startobj = hitInfo.collider.gameObject.GetComponentInParent<Transform>();
            if (startobj && startobj.tag.Equals("Startwords"))
            {
                Vector3 pos = new Vector3(startobj.position.x - 3.8f, startobj.position.y, startobj.position.z);
                GameObject obj =  Instantiate(ropePrefab, pos, Quaternion.identity);
                AllRopes.Add(obj);
               // Debug.Log(hitInfo.collider.gameObject.GetComponentInParent<Transform>().name);
                //Get matching name from map
                C_MatchingSolver.MatchNames.TryGetValue(startobj.name, out currentPuzzle);

                return obj.GetComponentInParent<Transform>().GetChild(1);
            }
        }
        startobj = null;
        return null;
    }


}
