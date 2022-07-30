using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteController : MonoBehaviour
{
    public Toggle delete;
    private GameObject highlightScript;
    [SerializeField] private LayerMask clickablesLayer;
    private Camera mainCamera;
    private bool deleteMode;

    private GameObject hitObject;
    // Start is called before the first frame update
    void Start()
    {
        deleteMode = false;
    }

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void DetectObject()
    {
        RaycastHit rayHit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity))
        {
            if (rayHit.collider != null)
            {
                //check tag here
                Destroy(rayHit.collider.gameObject);
            } 
        }
    }

    public void enableDeleteMode()
    {
        deleteMode = true;
    }
    
    public void disableDeleteMode()
    {
        deleteMode = false;  
    }

    public void deleteObject()
    {
        Destroy(hitObject);
    }
    
    
    

    // Update is called once per frame
    void Update()
    {
        if (deleteMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit rayHit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity))
                {
                    if (rayHit.collider != null)
                    {
                        //check tag here
                        Destroy(rayHit.collider.gameObject);
                    } 
                }
            }
        }
    }
}
