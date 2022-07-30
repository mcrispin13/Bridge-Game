using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableNodeVis : MonoBehaviour
{
    private Renderer renderer;
    public Color startColor, hoverColor, clickColor;
    public static bool mouseIsOver;

    AudioSource[] uiSounds;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = startColor;

        uiSounds = GetComponents<AudioSource>();

        mouseIsOver = false;

        
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

    }
    private void OnMouseDown()
    {
        uiSounds[1].Play();
        renderer.material.color = clickColor;
    }

}
