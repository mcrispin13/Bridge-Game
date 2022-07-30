using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camswitch : MonoBehaviour
{
    
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
            cam1.SetActive(true);
            cam2.SetActive(false);
            cam3.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.X)){
            cam1.SetActive(false);
            cam2.SetActive(true);
            cam3.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.C)){
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
        }
        
    }
}
