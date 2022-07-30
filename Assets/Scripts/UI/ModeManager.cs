using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public bool drawMode;
    public bool dragMode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDraw()
    {
        drawMode = true;
        dragMode = false;
    }
    
    public void setDrag()
    {
        drawMode = false;
        dragMode = true;
    }
}
