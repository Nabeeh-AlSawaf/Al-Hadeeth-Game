using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Save 
{
    public List<Hadeeth> HadeethList;
    public int version;



    public Hadeeth GetHadeeth(int num) {

        return HadeethList[num];
    }
    public void UpdateHadeethList(int ver)
    {
        if(version < ver)
        {
            //do logic
        }
    }

}


