using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNodeVisuals : MonoBehaviour
{
    private Renderer renderer;
    

    public Color startColor, hoverColor, clickColor;

    AudioSource[] uiSounds;

    public static bool mouseIsOver;

    AudioSource mouseover, mouseClick;

    bool soundReady;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = startColor;

        uiSounds = GetComponentsInParent<AudioSource>();
        
        mouseIsOver = false;

        soundReady = true;
    }
    private void OnMouseEnter()
    {
        uiSounds[0].Play();
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

        soundReady = true;
    }
    private void OnMouseDown()
    {
        uiSounds[1].Play();
        renderer.material.color = clickColor;
    }

}
