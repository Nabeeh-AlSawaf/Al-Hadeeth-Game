using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_PickUpPuzzel : MonoBehaviour
{
    public float forceAmount = 3;

    Transform selectedRigidbody;
    Camera targetCamera;
    Vector3 originalScreenTargetPosition;
    Vector3 originalRigidbodyPos;
    float selectionDistance;

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
            selectedRigidbody = GetRigidbodyFromMouseClick();
        }
        if (Input.GetMouseButtonUp(0) && selectedRigidbody)
        {
            //Release selected Rigidbody if there any
            Vector3 dragingObjectypPosition = new Vector3(selectedRigidbody.position.x, selectedRigidbody.position.y - 2f, selectedRigidbody.position.z);
            selectedRigidbody.position = Vector3.MoveTowards(selectedRigidbody.position, dragingObjectypPosition, forceAmount * Time.deltaTime);
            selectedRigidbody = null;
        }
    }

    void FixedUpdate()
    {
        if (selectedRigidbody)
        {
            float planeY = 0;
            Transform draggingObject = selectedRigidbody.transform;

            Plane plane = new Plane(Vector3.up, Vector3.up * planeY); // ground plane

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float distance; // the distance from the ray origin to the ray intersection of the plane
            if (plane.Raycast(ray, out distance))
            {
                draggingObject.position = ray.GetPoint(distance); // distance along the ray
                Vector3 dragingObjectypPosition = new Vector3(draggingObject.position.x, draggingObject.position.y + 2f, draggingObject.position.z);
                draggingObject.position = Vector3.MoveTowards(draggingObject.position, dragingObjectypPosition, forceAmount * Time.deltaTime);
            }
        }
    }

    Transform GetRigidbodyFromMouseClick()
    {
        RaycastHit hitInfo = new RaycastHit();
        Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);
        bool hit = Physics.Raycast(ray, out hitInfo);
        if (hit)
        {
            if (hitInfo.collider.gameObject.GetComponent<Rigidbody>())
            {
                selectionDistance = Vector3.Distance(ray.origin, hitInfo.point);
                originalScreenTargetPosition = targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance));
                originalRigidbodyPos = hitInfo.collider.transform.position;
                return hitInfo.collider.gameObject.GetComponent<Transform>();
            }
        }

        return null;
    }


}
