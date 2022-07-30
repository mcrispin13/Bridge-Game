using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject staticCam;
    public GameObject flyCam;
    // Start is called before the first frame update
    void Start()
    {
        staticCam.SetActive(true);  
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCamera();
    }
    void SwitchCamera()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P is pressed");

            if (staticCam.activeInHierarchy)
            {
                flyCam.SetActive(true);
                staticCam.SetActive(false);
            }
            else if (flyCam.activeInHierarchy)
            {
                Cursor.lockState = CursorLockMode.None;
                flyCam.SetActive(false);
                staticCam.SetActive(true);
                flyCam.transform.position = staticCam.transform.position;
                flyCam.transform.rotation = staticCam.transform.rotation;
            }
        }
        
    }

}
