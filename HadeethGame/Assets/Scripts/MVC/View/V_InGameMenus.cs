using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class V_InGameMenus : MonoBehaviour
{
    #region public vars
    public GameObject ratingWindow;
    public GameObject gameMenu;
    public GameObject pauseMenu;
    public GameObject controlPanel;
    public GameObject settingsMenu;
    #endregion
    #region private vars
    private Action CurrentAction { get; set; }

    #endregion
    public void Start()
    {
        Time.timeScale = 0f;
        gameMenu.SetActive(true);
    }

    public void StartGame()
    {
        gameMenu.SetActive(false);
        controlPanel.SetActive(true);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        CurrentAction = delegate
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Start");
        };
        V_Confirmation.InitializeMessage(CurrentAction, "Are you sure?");

       
    }
    public void Resume()
    {
        controlPanel.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void PauseMenu()
    {
        controlPanel.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void RatingWindow()
    {
        ratingWindow.SetActive(true);
    }
    public void GameMenu() 
    {
        gameMenu.SetActive(true);
    }
    public void SettingsMenu()
    {
        settingsMenu.SetActive(true);
    }
}
