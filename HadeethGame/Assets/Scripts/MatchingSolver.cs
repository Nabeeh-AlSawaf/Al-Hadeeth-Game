using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingSolver : MonoBehaviour
{
    public static string currentMatch = "";

    public void OnCollisionEnter(Collision collision)
    {
        currentMatch = collision.gameObject.name;
        Debug.Log("MATCH IS : " + currentMatch);
    }
    public void OnCollisionExit(Collision collision)
    {
        currentMatch = "";
    }
}
