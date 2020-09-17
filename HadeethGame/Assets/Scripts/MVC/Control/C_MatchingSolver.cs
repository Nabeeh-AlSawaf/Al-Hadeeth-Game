using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_MatchingSolver : MonoBehaviour
{
    public static Dictionary<string, Vector3> MatchWords = new Dictionary<string, Vector3>();

    public static Dictionary<string, string> MatchNames = new Dictionary<string, string>();
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public bool getMatchingPosition(string startWord, out Vector3 Match)
    {
        if (MatchWords.TryGetValue(startWord, out Match))
            return true;
        else
            return false;

    }

}
