using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class Save 
{
    public List<Hadeeth> HadeethList;
    public int version;
    private  const int  NumberOfHadeeth = 40; 


    public Hadeeth GetHadeeth(int num) {

        return HadeethList[num];
    }
    public void UpdateHadeethList(int ver)
    {
        if(version < ver)
        {
            string jsonResult;
            if (File.Exists(Application.persistentDataPath + "//Save.json"))
            {
                for (int id = 0; id < NumberOfHadeeth; id++)
                {
                     jsonResult = File.ReadAllText(Application.persistentDataPath + "//Save.json"); // change api bla bla  by hadeeth id
                    HadeethList[id] = JsonUtility.FromJson<Hadeeth>(jsonResult);
                }

                //  Debug.Log(settings.ToString()); //checking what it read
            }
        }
    }

}


