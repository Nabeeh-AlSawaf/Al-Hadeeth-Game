using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.Play();
        Debug.Log(anim.isPlaying);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playAnim()
    {
        anim.Play();
        Debug.Log(anim.isPlaying);
    }
}
