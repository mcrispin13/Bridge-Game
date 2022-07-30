using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left alt"))
        {
            ScreenshotHandler.TakeScreenshot_Static(Screen.width, Screen.height);
        }
    }
}
