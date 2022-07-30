using System;
using System.Collections;
using System.Collections.Generic;
using EasyCurvedLine;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NewMain : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LayerMask clickablesLayer;

    private List<GameObject> selectedObjects;
    public GameObject go1;
    public GameObject go2;
    public GameObject roadPrefab, pylonPrefab; //HECTORS CHANGE 
    private GameObject cablePrefab;
    [SerializeField] public GameObject cablePrefab1;
    [SerializeField] public GameObject cablePrefab2;
    [SerializeField] public GameObject cablePrefab3;
    [SerializeField] public GameObject ObjectArray;
    [SerializeField] public GameObject cubePrefab;
    public int cableIndex;
    private List<GameObject> connectedObjects;
    [HideInInspector] public GameObject[] BaseNodes, CableNodes;
    private GameObject connection;
    public Vector3 firstPos;
    public Vector3 secondPos;
    //LineRenderer l;
    List<Vector3> points2 = new List<Vector3>();
    List<Vector3> points = new List<Vector3>();
    List<Vector3> bufferpoints2 = new List<Vector3>();
    List<Vector3> bufferpoints = new List<Vector3>();
    //public TMP_Text budgetText;
    public GameObject buffer;
    public int initScore = 1000;

    public static bool cableMode, pylonMode;

    [SerializeField] public Dropdown dropdown;
    /*public GameObject iron;
    public GameObject steel;
    public GameObject wood;*/

    private GameObject lastChild;

    private Color cableColor;

    private int lastChildIndex;

    private GameObject lastChildObject;

    CableNodeVis cbv;

    CableNodeVis[] CableNodesArr;

    //Add list for connected gameobjects
    public int menuIndex;
    
    void Start()
    {
        
        cableIndex = 1;
        cableColor = Color.black;
        selectedObjects = new List<GameObject>();
        connectedObjects = new List<GameObject>();

        BaseNodes = GameObject.FindGameObjectsWithTag("BaseNode");
        

        //l = gameObject.AddComponent<LineRenderer>();
        //budgetText.text = "$" + initScore.ToString();
        //int menuIndex = dropdown.GetComponent<Dropdown> ().value;

    }
    //switch to drawing cables
    public void activateCable()
    {

       
        cableMode = true;
        pylonMode = false;
        
    }
    //switch to drawing pylons
    public void activatePylon()
    {
        
        for (int i = 0; i < BaseNodes.Length; i++)
        {
            BaseNodes[i].SetActive(true);
        }
        cableMode = false;
        pylonMode = true;
    }
    
    public void UndoRecent()
    {
        lastChildIndex = ObjectArray.transform.childCount - 1;
        lastChildObject = ObjectArray.transform.GetChild(lastChildIndex).gameObject;
        Destroy (lastChildObject);
    }

    public void materia1()
    {
        cableIndex = 1;
    }
    
    public void materia2()
    {
        cableIndex = 2;
    }
    
    public void materia3()
    {
        cableIndex = 3;
    }
    
    
    //lastChild = transform.GetChild(transform.childCount - 1);

    // Update is called once per frame
    void Update()
    {
        //NOW IMPLEMENTATION: LEFT ALT+LEFT SHIFT - on left-alt pressed
        if (Input.GetKey("left alt"))
        {
            //on mouse button down pressed
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit rayHit;
                //raycast returns true if ray intersects with with a collider
                //(Origin) starting point = mousePosition
                //direction of ray
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity,
                    clickablesLayer))
                {
                    ClickOn clickOnScript = rayHit.collider.GetComponent<ClickOn>();

                    points.Add(rayHit.collider.gameObject.transform.position);
                    points2.Add(rayHit.collider.gameObject.transform.position + new Vector3(0.0f, 0.0f, 2f));
                    Debug.Log("Hit");



                    //if (Input.GetKey("left shift"))
                    while (rayHit.collider.gameObject.transform.position != points[0])
                    {

                        points.Add(rayHit.collider.gameObject.transform.position); //Add second click point

                        if (points[0] != points[1])
                        {
                            


                            if (cableMode)
                            {
                                if (cableIndex == 1)
                                {
                                    cablePrefab = cablePrefab1;
                                }

                                else if (cableIndex == 2)
                                {
                                    cablePrefab = cablePrefab2;
                                }

                                else
                                {
                                    cablePrefab = cablePrefab3;
                                }

                                GameObject cableInstance =
                                    Instantiate(cablePrefab, firstPos, Quaternion.identity) as GameObject;



                                initScore -= 10;
                                //   budgetText.text = "$" + initScore.ToString();
                                cableInstance.transform.GetChild(0).gameObject.transform.position = points[0];
                                cableInstance.transform.GetChild(1).gameObject.transform.position = points[1];
                                //cableInstance.transform.GetChild(0).GetComponent<CableComponent>().cableMaterial.color = cableColor;
                                //buffer = cableInstance;

                                GameObject cableInstance2 =
                                    Instantiate(cablePrefab, firstPos, Quaternion.identity) as GameObject;
                                cableInstance2.transform.GetChild(0).gameObject.transform.position = points2[0];
                                cableInstance2.transform.GetChild(1).gameObject.transform.position = points2[1];
                                //cableInstance2.transform.GetChild(0).GetComponent<CableComponent>().cableMaterial.color = cableColor;
                                
                                GameObject cable = new GameObject("Cable");
                                //cableInstance.transform.parent = GameObject.Find("Cable").transform;
                                cableInstance.transform.parent = cable.transform;
                                cableInstance2.transform.parent = cable.transform;
                                cable.tag = "CableTag";
                                cable.layer = LayerMask.NameToLayer("Structure");
                                cable.transform.parent = ObjectArray.transform;

                                points.Clear();
                                points2.Clear();


                                selectedObjects.Clear();
                            }

                            


                            if (pylonMode)
                            {
                                GameObject pylonInstance =
                                    Instantiate(pylonPrefab, firstPos, Quaternion.identity) as GameObject;

                                float distance = Vector3.Distance(points[0], points[1]) - 1;

                                pylonInstance.transform.localScale += new Vector3(0, distance, 0);
                                
                                GameObject pylon = new GameObject("Pylon");
                                //cableInstance.transform.parent = GameObject.Find("Cable").transform;
                                pylonInstance.transform.parent = pylon.transform;
                                pylon.transform.parent = ObjectArray.transform;
                                pylon.layer = LayerMask.NameToLayer("Structure");
                                // foreach (Transform child in pylonInstance.transform)
                                //     {
                                //         child.tag = "Pylon";
                                //     }

                                // pylonInstance.Find("Pylon1").tag = "Pylon";
                                // GameObject pylonChild1 = pylonInstance.Find("Pylon1");
                                // pylonChild1.tag = "Pylon";
                                // Transform pylonChild2 = pylonInstance.transform.Find("Pylon2");
                                // pylonChild2.gameObject.tag = "Pylon";

                                //miserable attempt to make cube child of each pylon, after unpacking prefab and then scaling 
                                /*GameObject cubeInstance1 =
                                    Instantiate(cubePrefab, firstPos, Quaternion.identity) as GameObject;
                                
                                GameObject cubeInstance2 =
                                    Instantiate(cubePrefab, firstPos, Quaternion.identity) as GameObject;
                                
                                Transform t1 = pylonInstance.GetComponentInChildren<Transform>().Find("PylonFirst");
                                
                                Transform t2 = pylonInstance.GetComponentInChildren<Transform>().Find("PylonSecond");

                                cubeInstance1.transform.parent = t1.transform;

                                cubeInstance2.transform.parent = t2.transform;*/




                                initScore -= 10;
                                //   budgetText.text = "$" + initScore.ToString();
                                //pylonInstance.transform.GetChild(0).gameObject.transform.position = points[0];
                                // pylonInstance.transform.GetChild(1).gameObject.transform.position = points[1];


                                pylon.tag = "PylonTag";
                                pylonInstance.transform.position = points[0]; //We really want to be instantiating this in between them, rather than instantiating at one of them 



                                //buffer = pylonInstance;

                                /* GameObject pylonInstance2 =
                                     Instantiate(pylonPrefab, firstPos, Quaternion.identity) as GameObject;
                                 pylonInstance2.transform.GetChild(0).gameObject.transform.position = points2[0];
                                 pylonInstance2.transform.GetChild(1).gameObject.transform.position = points2[1];
                                 */
                                points.Clear();
                                points2.Clear();


                                selectedObjects.Clear();
                            }

                        }

                        else
                        {
                            points.Clear();
                        }

                        clickOnScript.currentlySelected = true;
                        clickOnScript.clickMe();
                        // }


                        selectedObjects.Remove(rayHit.collider.gameObject);
                        clickOnScript.currentlySelected = false;
                        clickOnScript.clickMe();



                    }
                }
            }
        }


        if (cableMode) //NEED TO MAKE THIS ONLY RUN ONCE, WILL DO IT SOON 
        {
            for (int i = 0; i < BaseNodes.Length; i++)
            {
                BaseNodes[i].SetActive(false);
            }

            for (int i = 0; i < CableNodes.Length; i++)
            {
                CableNodes[i].SetActive(true);
            }

        }
        if (pylonMode) //NEED TO MAKE THIS ONLY RUN ONCE, WILL DO IT SOON  
        {
            for (int i = 0; i < BaseNodes.Length; i++)
            {
                BaseNodes[i].SetActive(true);
            }
            for (int i = 0; i < CableNodes.Length; i++)
            {
                CableNodes[i].SetActive(false);
            }
        }
    }
}