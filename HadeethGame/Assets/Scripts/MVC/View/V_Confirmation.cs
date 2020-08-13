using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_Confirmation : MonoBehaviour
{
    #region Private Vars
    private static Action Action { get; set; }
    private static GameObject ConfirmationWindow { get; set; }
    private static GameObject BlurLayer { get; set; }

    #endregion
    void Awake()
    {
        ConfirmationWindow = this.gameObject.transform.GetChild(1).gameObject;
        BlurLayer = this.gameObject.transform.GetChild(0).gameObject;
    }
    /// <summary>
    /// The function to be called using the unity buttons
    /// By : Nabeeh Sawaf
    /// </summary>
    /// <param name="State"></param>
    public void Confirm( bool State)
    {
        if (State) 
            Action();

        Action = null;
        ConfirmationWindow.SetActive(false);
        BlurLayer.SetActive(false);

    }

    /// <summary>
    /// Initilizer for the message
    /// By : Nabeeh Sawaf
    /// </summary>
    /// <param name="action"> Sets the Action that's to be Taken </param>
    /// <param name="dialog"> Sets the Dialog Message for the user </param>
    public static void InitializeMessage(Action action, string dialog)
    {
        Action = action;
        ConfirmationWindow.SetActive(true);
        BlurLayer.SetActive(true);
        //Dialog is the 2nd Text in the Texts game object (looks bad T^T)
        ConfirmationWindow.transform.GetChild(0).GetChild(1).GetComponent<ArabicText>().Text = dialog;
    }


}
