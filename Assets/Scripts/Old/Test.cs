using System;
using System.Collections;
using System.Collections.Generic;
using EasyCurvedLine;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LayerMask clickablesLayer;

    private List<GameObject> selectedObjects;
    public GameObject go1;
    public GameObject go2;
    public GameObject roadPrefab, pylonPrefab; //HECTORS CHANGE 
    [SerializeField] public GameObject cablePrefab;
    private List<GameObject> connectedObjects;
    private GameObject connection;
    public Vector3 firstPos;
    public Vector3 secondPos;
    LineRenderer l;
    List<Vector3> points2 = new List<Vector3>();
    List<Vector3> points = new List<Vector3>();
    public TMP_Text budgetText;
    public GameObject buffer;
    public int initScore = 1000;
    
    /*public GameObject iron;
    public GameObject steel;
    public GameObject wood;*/

    //Add list for connected gameobjects

    void Start()
    {
        selectedObjects = new List<GameObject>();
        connectedObjects = new List<GameObject>();
        l = gameObject.AddComponent<LineRenderer>();
       // budgetText.text = "$" + initScore.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit rayHit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity,
                clickablesLayer))
            {
                ClickOn clickOnScript = rayHit.collider.GetComponent<ClickOn>();

                points.Add(rayHit.collider.gameObject.transform.position);
                points2.Add(rayHit.collider.gameObject.transform.position+new Vector3(0.0f,0.0f,1f));


                #region HECTOR EXPERIMENTING W/ ROAD PLACEMENT

                if (Input.GetKey("left ctrl"))
                {
                    if (clickOnScript.currentlySelected == false) //Check if already selected
                    {
                        points.Add(rayHit.collider.gameObject.transform.position); //Add second click point
                        points2.Add(rayHit.collider.gameObject.transform.position+new Vector3(0.0f,0.0f,0.0f));
                        if (points[0] != points[1])
                        {
                            float xAverage = (points[0].x + points[1].x) / 2;

                            GameObject roadInstance =
                                Instantiate(roadPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;

                            initScore -= 10;
                            budgetText.text = "$" + initScore.ToString();

                            roadInstance.transform.gameObject.transform.position = new Vector3(xAverage, points[0].y, points[0].z); //THIS IS WHERE YOU REMOVE DTHE CHILD 


                            points.Clear();
                            
                            
                            
                        }

                        else
                        {
                            points.Clear();
                            points2.Clear();
                        }

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
                #endregion


                else if (Input.GetKey("left shift"))
                {
                    if (clickOnScript.currentlySelected == false) //Check if already selected
                    {
                        points.Add(rayHit.collider.gameObject.transform.position); //Add second click point

                        if (points[0] != points[1])
                        {
                            float yAverage = (points[0].y + points[1].y) / 2;

                            GameObject pylonInstance =
                                Instantiate(pylonPrefab, new Vector3(points[0].x, yAverage, points[0].z), Quaternion.identity) as GameObject;

                            initScore -= 10;
                         //   budgetText.text = "$" + initScore.ToString();

                            // pylonInstance.transform.gameObject.transform.position = new Vector3(points[0].x, yAverage, points[0].z); //THIS IS WHERE YOU REMOVE DTHE CHILD 
                            


                            points.Clear();

                        }

                        else
                        {
                            points.Clear();
                        }

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
                
                if (Input.GetKey("left alt"))
                {
                    if (clickOnScript.currentlySelected == false) //Check if already selected
                    {
                        points.Add(rayHit.collider.gameObject.transform.position); //Add second click point

                        if (points[0] != points[1])
                        {
                            /*GameObject cableInstance =
                                Instantiate(Resources.Load("Cable"), firstPos, Quaternion.identity) as GameObject;*/
                            
                            GameObject cableInstance =
                                Instantiate(cablePrefab, firstPos, Quaternion.identity) as GameObject;

                            initScore -= 10;
                            budgetText.text = "$" + initScore.ToString();
                            cableInstance.transform.GetChild(0).gameObject.transform.position = points[0];
                            cableInstance.transform.GetChild(1).gameObject.transform.position = points[1];
                            buffer = cableInstance;
                            
                            GameObject cableInstance2 =
                                Instantiate(cablePrefab, firstPos, Quaternion.identity) as GameObject;
                            cableInstance2.transform.GetChild(0).gameObject.transform.position = points2[0];
                            cableInstance2.transform.GetChild(1).gameObject.transform.position = points2[1];
                            
                            points.Clear();
                            points2.Clear();
                        }

                        else
                        {
                            points.Clear();
                        }

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