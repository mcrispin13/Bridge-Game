using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverOver : MonoBehaviour
{
    public Color startColor;
    public Color mouseOverColor;
    private bool mouseOver = false;
    

    private void OnMouseEnter()
    {
        mouseOver = true;
        GetComponent<Renderer>().material.SetColor("_Color",mouseOverColor);
    }

    private void OnMouseExit()
    {
        mouseOver = false;
        GetComponent<Renderer>().material.SetColor("_Color",startColor);
    }
}
