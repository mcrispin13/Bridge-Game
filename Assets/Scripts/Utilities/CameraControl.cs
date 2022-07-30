using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform[] views;
    Camera m_MainCamera;
    public float transitionSpeed;

    public Transform currentView ;
    
    Vector3 temp = new Vector3(6.63f,6.15f,0);
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentView = views[0];
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentView = views[1];
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.localPosition, currentView.localPosition, Time.deltaTime * transitionSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, currentView.rotation, Time.deltaTime * transitionSpeed);
    }
}
