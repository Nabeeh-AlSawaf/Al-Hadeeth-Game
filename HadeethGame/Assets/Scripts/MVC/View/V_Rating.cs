using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class V_Rating : MonoBehaviour
{
    #region public vars
    public Image rateFiller;
    public GameObject rateWindow;
    public GameObject gameMenu;
    public ArabicText test;
    #endregion

    #region private vars
    private SaveManager save = new SaveManager();


    #endregion

    public void SetFillRate(float rate)
    {
        rateFiller.fillAmount = rate;
    }
    public void Confirm()
    {
        save.UpdateScore(GlobalVariables.HadeethNumber, "cars" , rateFiller.fillAmount);
        rateWindow.SetActive(false);
        gameMenu.SetActive(true);
    }
}
