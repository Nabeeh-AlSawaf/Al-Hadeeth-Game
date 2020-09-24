using UnityEngine;
using System.Collections;
using UnityEngine.UI; [RequireComponent(typeof(Button))] public class C_AudioOnClick : MonoBehaviour
{     public AudioClip sound;     private Button button { get { return GetComponent<Button>(); } }     private AudioSource source { get { return GetComponent<AudioSource>(); } }     // Use this for initialization     void Start()     {         gameObject.AddComponent<AudioSource>();
        if (gameObject.tag.Equals("QuitButton"))
            sound = GlobalVariables.buttonQuit;        else if (gameObject.tag.Equals("PauseButton"))
            sound = GlobalVariables.buttonPause;
        else if(gameObject.tag.Equals("ContinueButton"))
            sound = GlobalVariables.buttonHyped;
        else
            sound = GlobalVariables.buttonSFX;
        source.clip = sound;        source.playOnAwake = false;        button.onClick.AddListener(() => PlaySoud());     }     void PlaySoud()     {        if(sound)         source.PlayOneShot(sound);     } }