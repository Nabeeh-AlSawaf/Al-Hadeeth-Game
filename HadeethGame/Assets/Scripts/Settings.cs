using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Settings
{
    public bool MuteMusic;
    public bool MuteAll;
    public bool Sound;
    public bool Arabic;
    public bool Graphics;
    public float example;

    public override string ToString()
    {
        return $"{{{nameof(MuteMusic)}={MuteMusic.ToString()}, {nameof(MuteAll)}={MuteAll.ToString()}, {nameof(Sound)}={Sound.ToString()}, {nameof(Arabic)}={Arabic.ToString()}, {nameof(Graphics)}={Graphics.ToString()}, {nameof(example)}={example.ToString()}}}";
    }
}

