using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_CartColors : MonoBehaviour
{
    public Color dark;
    public Color mid;
    public Color light;

    public Material darkMat;
    public Material midMat;
    public Material lightMat;
    public static int listLen=0;

    public M_CartColors(Color dark,Color mid,Color light)
    {
        darkMat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        midMat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        lightMat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        this.dark = dark;
        this.mid = mid;
        this.light = light;

        darkMat.color = dark;//.SetColor("_BaseColor",dark);
        midMat.color = mid;//.SetColor("_BaseColor", mid);
        lightMat.color = light;//.SetColor("_BaseColor", light);
        listLen++;
    }
    public static List<M_CartColors> carts = new List<M_CartColors>(){

    new M_CartColors(
        new Color(1, 0.305f, 0.305f),
        new Color(1, 0.541f, 0.541f),
        new Color(1, 0.654f, 0.654f)
        ),
    new M_CartColors(
        new Color(0.305f , 1, 0.305f ),
        new Color(0.541f, 1, 0.541f),
        new Color(0.654f, 1, 0.654f)
        ),
    new M_CartColors(
        new Color(0.305f, 0.305f, 1),
        new Color(0.541f, 0.541f, 1),
        new Color(0.654f, 0.654f, 1)
        ),
    new M_CartColors(
        new Color(1, 0.631f, 0.305f),
        new Color(1, 0.788f, 0.541f),
        new Color(1, 0.772f, 0.654f)
        ),
    new M_CartColors(
        new Color(1, 0.854f, 0.305f),
        new Color(1, 0.917f, 0.541f),
        new Color(1, 0.917f, 0.654f)
        ),
    new M_CartColors(
        new Color(0.666f, 1, 0.305f),
        new Color(0.854f, 1, 0.541f),
        new Color(0.843f, 1, 0.654f)
        ),
    new M_CartColors(
        new Color(0.337f, 1, 0.305f),
        new Color(0.568f, 1, 0.541f),
        new Color(0.678f, 1, 0.654f)
        ),
    new M_CartColors(
        new Color(0.305f, 1, 0.8f),
        new Color(0.541f, 1, 0.827f),
        new Color(0.654f, 1, 0.843f)
        ),
    new M_CartColors(
        new Color(0.305f, 0.909f, 1),
        new Color(0.541f, 0.956f, 1),
        new Color(0.654f, 1, 0.992f)
        ),
    new M_CartColors(
        new Color(0.305f, 0.670f, 1),
        new Color(0.541f, 0.792f, 1),
        new Color(0.654f, 0.858f, 1)
        ),
    new M_CartColors(
        new Color(0.305f, 0.454f, 1),
        new Color(0.541f, 0.650f, 1),
        new Color(0.654f, 0.752f, 1)
        ),
    new M_CartColors(
        new Color(0.482f, 0.305f, 1),
        new Color(0.592f, 0.541f, 1),
        new Color(0.717f, 0.654f, 1)
        ),
    new M_CartColors(
        new Color(0.686f, 0.305f, 1),
        new Color(0.752f, 0.541f, 1),
        new Color(0.831f, 0.654f, 1)

        ),
    new M_CartColors(
        new Color(1, 0.305f, 0.984f),
        new Color(0.956f, 0.541f, 1),
        new Color(1, 0.654f, 0.996f)

        ),
    new M_CartColors(
        new Color(1, 0.305f, 0.674f),
        new Color(1, 0.541f, 0.772f),
        new Color(1, 0.654f, 0.843f)

        ),
    };
}


    