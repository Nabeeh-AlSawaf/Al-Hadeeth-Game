using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRepeating : MonoBehaviour
{
    public AudioSource[] childRepeat;
    public AudioSource mainSpeaker;
    public AudioClip[] hadeethClips;
    public int currentClip = 0;
    public int hadeethSize = 10;//get the number of the hadeeth parts from api

    // Start is called before the first frame update
    void Start()
    {
      //  hadeethClips = new AudioClip[hadeethSize]; 
    }
    public void startMain()
    {
        mainSpeaker.clip = hadeethClips[currentClip];
        mainSpeaker.PlayDelayed(1f);
        StartCoroutine(WaitSpeakerPlay());
    }
    public void startChildRepeat() {

        float delay = 1f;
        foreach(var child in  childRepeat){
            child.clip = hadeethClips[currentClip];
            child.PlayDelayed(delay);
        }
 
        StartCoroutine(WaitChildPlay());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WaitChildPlay()
    {
        yield return new WaitUntil(() => childRepeat[0].isPlaying == false);
        currentClip++;
        if (currentClip < hadeethSize)
        {
            startMain();    
        }
        else
        {
            Debug.Log("array of hdaeeth is over");
        }
    }
    IEnumerator WaitSpeakerPlay()
    {
        yield return new WaitUntil(() => mainSpeaker.isPlaying == false);
        startChildRepeat();

    }


}
