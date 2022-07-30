using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class InitiateConnection : MonoBehaviour
{
    
    // Start is called before the first frame update

    private GameObject connection;

    void Update()
    {
        if( Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
            RaycastHit hit;

            if( Physics.Raycast( ray, out hit, 100 ) )
            {
                //Debug.Log( hit.transform.gameObject.name );
                connection = new GameObject("Connection");
                connection.AddComponent<UnityLineRendererTest>();
                connection.GetComponent<UnityLineRendererTest>().go1 = hit.transform.gameObject;
            }
            
            //Current Issue: Script being added to all the cubes with the same selected cube as first connection point. 
            
            //TODO: Wait for second cube to be selected, and assign the transform of the second gameobject to the script for the connection.
            
           
            
        }
    }
}
