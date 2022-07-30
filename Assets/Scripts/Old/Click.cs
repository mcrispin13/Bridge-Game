using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LayerMask clickablesLayer;

    private List<GameObject> selectedObjects;

    public GameObject go1;
    public GameObject go2;
    private List<GameObject> connectedObjects;
    private GameObject connection;
    LineRenderer l;
    List<Vector3> points = new List<Vector3>();
    
    
    
    //Add list for connected gameobjects

    void Start()
    {
        selectedObjects = new List<GameObject>();
        connectedObjects = new List<GameObject>();
        l = gameObject.AddComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit rayHit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity,clickablesLayer))
            {
                ClickOn clickOnScript = rayHit.collider.GetComponent<ClickOn>();
                points.Add(rayHit.collider.gameObject.transform.position);
                //Add Line Renderer Game Object here: DONE
                //Assign first gameObject here: DONE
                if (Input.GetKey("left ctrl"))
                {
                    if (clickOnScript.currentlySelected == false) //Check if already selected
                    {
                        selectedObjects.Add(rayHit.collider.gameObject);
                        points.Add(rayHit.collider.gameObject.transform.position);
                        l.startWidth = 0.1f;
                        l.endWidth = 0.1f;
                        l.SetPositions(points.ToArray());
                        l.useWorldSpace = true;
                        Debug.Log(points);
                        //Before implementing code, check if the second selected object is the second object in the array
                        //Based on that, assign second game object to the second object reference in line renderer
                        
                        //Add connection gameobject to connected game objects list

                        clickOnScript.currentlySelected = true;
                        clickOnScript.clickMe();
                    }

                    else
                    {
                        selectedObjects.Remove(rayHit.collider.gameObject);
                        clickOnScript.currentlySelected = false;
                        clickOnScript.clickMe();
                    }
                }
                else
                {
                    if (selectedObjects.Count > 0)
                    {
                        foreach (GameObject obj in selectedObjects)
                        {
                            obj.GetComponent<ClickOn>().currentlySelected = false;
                            obj.GetComponent<ClickOn>().clickMe();
                        }
                        
                        selectedObjects.Clear();
                    }
                    
                    selectedObjects.Add(rayHit.collider.gameObject);
                    clickOnScript.currentlySelected = true;
                    clickOnScript.clickMe();
                }
                
            }
        } 
    }
}
