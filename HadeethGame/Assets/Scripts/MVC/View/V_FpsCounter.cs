using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_FpsCounter : MonoBehaviour
{
    string label = "";
    float count;


    IEnumerator Start()
    {
        Application.targetFrameRate = 60;
        Screen.SetResolution(1280, 720, true);
        GUI.depth = 2;
        while (true)
        {
            if (Time.timeScale == 1)
            {
                yield return new WaitForSeconds(0.1f);
                count = (1 / Time.deltaTime);
                label = "FPS :" + (Mathf.Round(count));
            }
            else
            {
                label = "Pause";
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(5, 40, 100, 25), label);
    }

    public void lowres()
    {
        Screen.SetResolution(800, 480, true);
    }

    public void midres()
    {

        Screen.SetResolution(1024, 576, true);

    }

    public void highres()
    {
        Screen.SetResolution(1280, 720, true);
    }
}
