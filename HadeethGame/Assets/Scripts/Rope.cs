using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<CharacterJoint>().connectedBody = gameObject.transform.parent.GetComponent<Rigidbody>();

    }

}
