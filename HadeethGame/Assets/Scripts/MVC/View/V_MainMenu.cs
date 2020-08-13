using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class V_MainMenu : MonoBehaviour
{
    #region public vars
    public GameObject settingsPanel;
    public GameObject soundPanel;
    public GameObject languagePanel;
    public GameObject videoPanel;
    public GameObject blurLayer;
    public GameObject GlobalVars;
    public Toggle toggle;
    public Toggle MuteMusic;
    public Toggle MuteAll;
    public Toggle Sound;
    public Toggle Arabic;
    public Toggle Graphics;
    public Slider example;
    Settings settings = new Settings();

    #endregion
    #region Private vars
    private Action CurrentAction { get; set; }
    #endregion
    void Start()
    {
        InitializeSettings();
        DontDestroyOnLoad(GlobalVars);
    }
    public void InitializeSettings()
    {
        M_MainMenu.InitializeSettings(ref settings);

            MuteMusic.isOn = settings.MuteMusic;
            MuteAll.isOn = settings.MuteAll;
            Sound.isOn = settings.Sound;
            Arabic.isOn = settings.Arabic;
            Graphics.isOn = settings.Graphics;
            example.value = settings.example;
            GlobalVariables.settings = settings;
        
    }

    public void ClickQuit()
    {
        CurrentAction = delegate
        {
            Application.Quit();
        };
        V_Confirmation.InitializeMessage(CurrentAction, "Are you sure?");
    }
    public void ClickStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void ClickSettings()
    {
        blurLayer.SetActive(true);
        settingsPanel.SetActive(true);

    }



    public void ClickShare()
    {
        string subject = "Hadeeth Game";
        string body = "Try Hadeeth by Joybox it is an amazing game";
        //execute the below lines if being run on a Android device
#if UNITY_ANDROID
         //Refernece of AndroidJavaClass class for intent
          AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
         //Refernece of AndroidJavaObject class for intent
         AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
         //call setAction method of the Intent object created
         intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
         //set the type of sharing that is happening
         intentObject.Call<AndroidJavaObject>("setType", "text/plain");
         //add data to be passed to the other activity i.e., the data to be sent
         intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
         intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body);
         //get the current activity
         AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
         AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
         //start the activity by sending the intent data
         currentActivity.Call("startActivity", intentObject);
         intentClass.Dispose();
         unity.Dispose();

#endif
    }


    public void ClickSound()
    {
        soundPanel.SetActive(true);
        languagePanel.SetActive(false);
        videoPanel.SetActive(false);
    }

    public void ClickLanguage()
    {
        soundPanel.SetActive(false);
        languagePanel.SetActive(true);
        videoPanel.SetActive(false);
    }
    public void ClickVideo()
    {

        soundPanel.SetActive(false);
        languagePanel.SetActive(false);
        videoPanel.SetActive(true);
    }
    public void ClickConfirm()
    {
        //Debug.Log("saving " + MuteMusic.isOn);
        // json file to save (as settings file)
        //ToLower cause json only accept lower case letters

        CurrentAction = delegate
          {
              string json = "{ " +
         "\"MuteMusic\": " + MuteMusic.isOn.ToString().ToLower() +
         ",  \"MuteAll\":" + MuteAll.isOn.ToString().ToLower() +
         ",  \"Sound\":" + Sound.isOn.ToString().ToLower() +
         ",  \"Arabic\": " + Arabic.isOn.ToString().ToLower() +
         ",  \"Graphics\": " + Graphics.isOn.ToString().ToLower() +
         ",  \"example\":" + example.value +
         "}";

              //save to storage and to global vars
              GlobalVariables.settings = M_MainMenu.SaveSettings(json);

              blurLayer.SetActive(false);
              settingsPanel.SetActive(false);
          };
        
        V_Confirmation.InitializeMessage(CurrentAction, "Are you sure?");
        
    }




}
