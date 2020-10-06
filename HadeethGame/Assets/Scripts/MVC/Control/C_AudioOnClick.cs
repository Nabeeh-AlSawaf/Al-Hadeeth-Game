﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
{
        if (gameObject.tag.Equals("QuitButton"))
        {
            sound = GlobalVariables.buttonQuit;
        }
        {
            sound = GlobalVariables.buttonPause;
        }
        else if (gameObject.tag.Equals("ContinueButton"))
        {
            sound = GlobalVariables.buttonHyped;
        }
        else
        {
            sound = GlobalVariables.buttonSFX;
        }
        source.clip = sound;
        button.onClick.AddListener(() => PlaySoud());
        {
            source.volume = GlobalVariables.settings.SFXLevel;
            source.PlayOneShot(sound);
        }