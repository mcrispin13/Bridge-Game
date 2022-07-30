using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertNodeVisuals : MonoBehaviour
{
    private Renderer renderer;


    public Color startColor, hoverColor, clickColor;

    AudioSource[]   uiSounds;

    public static bool mouseIsOver;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = startColor;
        uiSounds = GetComponentsInParent<AudioSource>();
        mouseIsOver = false;
    }
    

    private void OnMouseOver()
    {
        renderer.material.color = hoverColor;
        mouseIsOver = true;
    }

    private void OnMouseExit()
    {
        mouseIsOver = false;
        renderer.material.color = startColor;
    }
    private void OnMouseDown()
    {
        uiSounds[1].Play();
        renderer.material.color = clickColor;
    }
}
