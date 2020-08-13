using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class V_MainScene : MonoBehaviour
{
    #region Public Vars
    public GameObject SelectionMenu;
    #endregion

    #region Private Vars
    private Action CurrentAction { get; set; }
    #endregion

    /// <summary>
    /// Hide the Selection Menu
    /// By: Nabeeh Sawaf
    /// </summary>
    public void HideSelectionMenu()
    {
        CurrentAction = delegate
        {
            SelectionMenu.SetActive(false);
            GlobalVariables.HadeethNumber = 0;
        };
        V_Confirmation.InitializeMessage(CurrentAction,"Are you sure?");
    }

    /// <summary>
    /// Show the Game Select Menu with chosen Hadeeth
    /// By: Nabeeh Sawaf
    /// </summary>
    /// <param name="HadeethNum"> must use in future </param>
    public void ShowSelections(int HadeethNumber)
    {
        GlobalVariables.HadeethNumber = HadeethNumber;
        SelectionMenu.SetActive(true);
    }

    #region Scene Loaders
    // FUNCTION FOR EACH SCENE IS INTENDED for future possibilities
    public void Puzzel()
    {
        SceneManager.LoadScene("Puzzle");
    }

    public void Cars()
    {
        SceneManager.LoadScene("Cars");
    }

    public void Train()
    {
        SceneManager.LoadScene("Train");
    }

    public void Matching()
    {
        SceneManager.LoadScene("Matching");
    }

    public void RepeatAfterMe()
    {
        SceneManager.LoadScene("RepeatAfterMe");
    }
    #endregion
}
