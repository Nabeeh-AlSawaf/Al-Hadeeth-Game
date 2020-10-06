using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PickUpCloud : MonoBehaviour
{



    public TrainManager trainManager;

    string currentPuzzle = "";

    string pickedArea = "";

    Transform solve;

    Transform puzzleClick;

    Vector3 basePuzzlePosition;

    Transform selectedPuzzle;
    Camera targetCamera;

    Vector3 m0;
    GameObject obj;
    Plane objPlane;

    // Start is called before the first frame update
    void Start()
    {
        targetCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = generateMouseRay();
            RaycastHit hit;

            if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit))
            {
                if (hit.transform.tag == "Cloud")
                {
                    obj = hit.transform.gameObject;
                    basePuzzlePosition = obj.transform.localPosition;

                    print("hit object " + obj);
                    objPlane = new Plane(Vector3.right, obj.transform.position);

                    Ray sray = targetCamera.ScreenPointToRay(Input.mousePosition);
                    float rayDistance;
                    objPlane.Raycast(sray, out rayDistance);
                    m0 = obj.transform.position - sray.GetPoint(rayDistance);
                }
            }
        }
        else if (Input.GetMouseButton(0) && obj)
        {
            //print("old " + obj.transform.position );

            Ray sray = targetCamera.ScreenPointToRay(Input.mousePosition);
            float raydistance;

            if (objPlane.Raycast(sray, out raydistance))
            {
              //  print("old " + obj.transform.position );
                obj.transform.position = sray.GetPoint(raydistance) + m0;
              //  print("new " + obj.transform.position);

            }
        }
        else if (Input.GetMouseButtonUp(0) && obj)
        {
  
            obj = null;
        }
       
    }

    void FixedUpdate()
    {


    }

    Ray generateMouseRay()
    {
        Vector3 mousePosFar = new Vector3(Input.mousePosition.x
            , Input.mousePosition.y
            , targetCamera.farClipPlane);
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x
            , Input.mousePosition.y
            , targetCamera.nearClipPlane);

        Vector3 mousePosF = targetCamera.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = targetCamera.ScreenToWorldPoint(mousePosNear);

        Ray ar = new Ray(mousePosN, mousePosF - mousePosN);
        return ar;

    }

    Transform GetPuzzelTransformFromMouseClick()
    {
        RaycastHit hitInfo = new RaycastHit();
        Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);
        bool hit = Physics.Raycast(ray, out hitInfo, 100);
        Debug.DrawRay(ray.origin, hitInfo.point, Color.green);
        if (hit)
        {
            var s = hitInfo.collider.gameObject.GetComponentInParent<Transform>();

            if (s&&s.tag == "Cloud")
            {
                Debug.Log(s.name);


                return hitInfo.collider.gameObject.GetComponentInParent<Transform>();
            }
        }

        return null;
    }
}
