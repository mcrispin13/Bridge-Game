using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightController : MonoBehaviour
{
    [SerializeField] public GameObject iron;
    [SerializeField] public GameObject steel;
    [SerializeField] public GameObject wood;
    // Start is called before the first frame update
    void Start()
    {
        iron.GetComponent<Outline2>().enabled = false;
        steel.GetComponent<Outline2>().enabled = false;
        wood.GetComponent<Outline2>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1")) { //Left Ctrl
            iron.GetComponent<Outline2>().enabled = true;
        } 
        else if(Input.GetButton("Fire2")) { //Left Alt
            steel.GetComponent<Outline2>().enabled = true;
        } 
        else if(Input.GetButton("Fire3")) { //Left Shift
            wood.GetComponent<Outline2>().enabled = true;
        }
        else
        {
            iron.GetComponent<Outline2>().enabled = false;
            steel.GetComponent<Outline2>().enabled = false;
            wood.GetComponent<Outline2>().enabled = false;
        }
    }
}
