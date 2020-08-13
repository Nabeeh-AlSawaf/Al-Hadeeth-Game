using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

#pragma warning disable IDE1006 // Naming Styles
public class M_MainMenu : MonoBehaviour
#pragma warning restore IDE1006 // Naming Styles
{
    public static void InitializeSettings(ref Settings settings)
    {
        string jsonResult;
        if (File.Exists(Application.persistentDataPath + "//Settings.json"))
        {
            jsonResult = File.ReadAllText(Application.persistentDataPath + "//Settings.json");
            settings = JsonUtility.FromJson<Settings>(jsonResult);

          //  Debug.Log(settings.ToString()); //checking what it read
        }
    }
    public static Settings SaveSettings(string json)
    {

        File.WriteAllText(Application.persistentDataPath + "//Settings.json", json);

       // Debug.Log("Saved in " + Application.persistentDataPath + "//Settings.json");

        return JsonUtility.FromJson<Settings>(json);
    }
}
