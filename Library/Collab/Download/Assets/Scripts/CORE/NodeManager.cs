using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeManager : MonoBehaviour
{

    public GameObject pylonPrefab, cablePrefab1, cablePrefab2, cablePrefab3, overBudgetText, ObjectArray;
    private GameObject cablePrefab, lastChildObject, selectedBaseNode;
    List<GameObject> cableNodes;
    Vector3[] points2;
    Vector3[] points;
    Vector3 buffer, emptyPos;
    Renderer rend, rend2;
    GameObject[] BaseNodes;
    GameObject[] cableNodesArr;
    public AudioSource construction, cableBuild, pylonThud;

    public TMP_Text budgetText; //DO THIS IN A MANAGER SCRIPT

    public int pylonPrice, cablePrice, initBudget, cableIndex;
    float cablePriceScaleFactor;
    private int lastChildIndex;

    bool runOnce = true;

    public static bool cableMode, pylonMode, startMode;
    
    // Start is called before the first frame update
    void Start()
    {
        points2 = new Vector3[2];
        points = new Vector3[2];

        emptyPos = new Vector3(0f, 0f, 0f);
        buffer = new Vector3(0, 0, 2.5f);

        BaseNodes = GameObject.FindGameObjectsWithTag("BaseNode");
        
        foreach(GameObject baseNode in BaseNodes)
        {
            MeshRenderer rend = baseNode.GetComponent<MeshRenderer>();
            rend.enabled = false;
        }

        

        initBudget = 1000;
        pylonPrice = 100;
        cablePrice = 75;
        budgetText.text = "$" + initBudget.ToString();
        
    }

    void BridgeCheck() //Populate cableNode array, turn off their renderers and colliders. 
    {
        
        if (runOnce)
        {
            foreach (GameObject cableNode in GameObject.FindGameObjectsWithTag("CableNode"))
            {
                BoxCollider BC = cableNode.GetComponent<BoxCollider>();
                BC.enabled = false;
                MeshRenderer rend = cableNode.GetComponent<MeshRenderer>();
                rend.enabled = false;
            }
        }
        
    }

    void Update()
    {
        ManageBaseNodes();
        ManageCableNodes();
        UpdateBudgetText();
        if (runOnce)
        {
            if (ItemSlot.bridgeActivated)
            {
               // construction.Play();
                BridgeCheck();
                runOnce = false;
            }
        }
    }
    
    
    
    #region Setup

    void UpdateBudgetText()
    {
        budgetText.text = "$" + initBudget.ToString();

        if (initBudget == 0 || initBudget < 0)
        {
            overBudgetText.SetActive(true);
        }
        else
        {
            overBudgetText.SetActive(false);
        }
    }

    public void activateCable()
    {
        foreach(GameObject cableNode in GameObject.FindGameObjectsWithTag("CableNode"))
        
        {
            MeshRenderer rend = cableNode.GetComponent<MeshRenderer>();
            rend.enabled = true;

            BoxCollider BC = cableNode.GetComponent<BoxCollider>();
            BC.enabled = true;
        }

        foreach (GameObject baseNode in BaseNodes)
        {
            MeshRenderer rend = baseNode.GetComponent<MeshRenderer>();
            rend.enabled = false;

            BoxCollider BC = baseNode.GetComponent<BoxCollider>();
            BC.enabled = false;
        }

        cableMode = true;
        pylonMode = false;

    }
    
    public void activatePylon()
    {
        foreach (GameObject cableNode in GameObject.FindGameObjectsWithTag("CableNode"))

        {
            MeshRenderer rend = cableNode.GetComponent<MeshRenderer>();
            rend.enabled = false;

            BoxCollider BC = cableNode.GetComponent<BoxCollider>();
            BC.enabled = false;
        }
        foreach (GameObject baseNode in BaseNodes)
        {
            MeshRenderer rend = baseNode.GetComponent<MeshRenderer>();
            rend.enabled = true;

            BoxCollider BC = baseNode.GetComponent<BoxCollider>();
            BC.enabled = true;
        }

        cableMode = false;
        pylonMode = true;
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

    public void UndoRecent()
    {
        lastChildIndex = ObjectArray.transform.childCount - 1;
        lastChildObject = ObjectArray.transform.GetChild(lastChildIndex).gameObject;
        Destroy(lastChildObject);
    }

    #endregion

    #region NodeManagement

    private void ManageCableNodes()
    {
        if (CableNodeVis.mouseIsOver) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit rayHit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity))
                {
                    if (rayHit.collider.tag == "CableNode")
                    {
                        if (points[0] == emptyPos)
                        {
                            points[0] = rayHit.collider.gameObject.transform.position;
                            points2[0] = rayHit.collider.gameObject.transform.GetChild(0).position; ;
                        }
                        
                        else if (points[0] != emptyPos)
                        {
                            if (cableMode)
                            {
                                switch (cableIndex)
                                {
                                    case 1:
                                        cablePrefab = cablePrefab1;
                                        cablePriceScaleFactor = 20;
                                        break;
                                    case 2:
                                        cablePrefab = cablePrefab2;
                                        cablePriceScaleFactor = 40f;
                                        break;
                                    case 3:
                                        cablePrefab = cablePrefab3;
                                        cablePriceScaleFactor = 60f;
                                        break;

                                    default:
                                        cablePrefab = cablePrefab1;
                                        cablePriceScaleFactor = 20;
                                        break;
                                }
                               
                            }
               
                            //collision deteection with start and end for road nodes, have a collider on nodes of ylon that detect if its receiving a start or an end. (FIRE JUDE)

                            points[1] = rayHit.collider.gameObject.transform.position;
                            points2[1] = rayHit.collider.gameObject.transform.GetChild(0).position;


                            GameObject cableInstance =
                            Instantiate(cablePrefab, rayHit.collider.gameObject.transform.position, Quaternion.identity);

                            cableInstance.transform.GetChild(0).gameObject.transform.position = points[0];
                            cableInstance.transform.GetChild(1).gameObject.transform.position = points[1];

                            

                            GameObject cableInstance2 =
                                Instantiate(cablePrefab, rayHit.collider.gameObject.transform.position, Quaternion.identity);
                            
                            cableInstance2.transform.GetChild(0).gameObject.transform.position = points2[0];
                            cableInstance2.transform.GetChild(1).gameObject.transform.position = points2[1];



                            //COST OF CABLES LOGIC

                            float cableLength = Vector3.Distance(points[0], points[1]);

                            cablePrice = (int)( cableLength * cablePriceScaleFactor);

                            initBudget = initBudget - cablePrice;

                            //END OF COST OF CABLES LOGIC 





                            points[0] = emptyPos;
                            points[1] = emptyPos;
                            points2[0] = emptyPos;
                            points2[1] = emptyPos;

                            GameObject cable = new GameObject("Cable");
                            //cableInstance.transform.parent = GameObject.Find("Cable").transform;
                            cableInstance.transform.parent = cable.transform;
                            cableInstance2.transform.parent = cable.transform;
                            cable.tag = "CableTag";
                            cable.layer = LayerMask.NameToLayer("Structure");
                            cable.transform.parent = ObjectArray.transform;
                            cableBuild.Play();
                            

                           

                        }

                    }
                }
            }
        }

        if (!CableNodeVis.mouseIsOver)
        {
            if (Input.GetMouseButton(0))
            {

                if (points[0] != emptyPos)
                {
                    points[0] = emptyPos;
                    points[1] = emptyPos;
                    points2[0] = emptyPos;
                    points2[1] = emptyPos;
                }
                else
                {
                    return;
                }
            }
        }
    }

    private void ManageBaseNodes()
    {
        if (BaseNodeVisuals.mouseIsOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit rayHit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity))
                {
                    if (rayHit.collider.tag == "BaseNode")
                    {
                        if (selectedBaseNode == null)
                        {
                            
                            selectedBaseNode = rayHit.collider.gameObject;
                            rend = selectedBaseNode.GetComponent<Renderer>();
                            rend.material.color = Color.green;
                            for (int i = 0; i < selectedBaseNode.transform.childCount; i++)
                            {
                                selectedBaseNode.transform.GetChild(i).gameObject.SetActive(true);
                            }
                        }

                        if (selectedBaseNode != null)
                        {
                            GameObject previousBaseNode = selectedBaseNode;
                            rend2 = previousBaseNode.GetComponent<Renderer>();
                            rend.material.color = Color.yellow;
                            selectedBaseNode = rayHit.collider.gameObject;

                            for (int i = 0; i < selectedBaseNode.transform.childCount; i++)
                            {
                                previousBaseNode.transform.GetChild(i).gameObject.SetActive(false);
                                selectedBaseNode.transform.GetChild(i).gameObject.SetActive(true);
                            }
                        }
                    }
                }
            }
        }

        if (VertNodeVisuals.mouseIsOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit rayHit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity))
                {
                    if (rayHit.collider.tag == "VertNode")
                    {
                        GameObject selectedVertNode = rayHit.collider.gameObject;

                        GameObject pylonInstance =
                                    Instantiate(pylonPrefab, selectedBaseNode.transform.position + new Vector3(0,0,.9f), Quaternion.identity) as GameObject;

                        selectedVertNode.transform.GetSiblingIndex();
                        //GET THE CHILD INDEX AND SELECT THE PYLON PREFAB BASED ON THAT


                        float distance = Vector3.Distance(selectedBaseNode.transform.position, selectedVertNode.transform.position) - 1;
                        float pylonCost = pylonPrice * distance;

                        initBudget = (int)(initBudget - pylonCost);

                        

                        pylonThud.Play();



                        for (int i = 0; i < selectedBaseNode.transform.childCount; i++)
                        {
                            selectedBaseNode.transform.GetChild(i).gameObject.SetActive(true);
                        }

                        
                        pylonInstance.transform.localScale += new Vector3(0, distance, 0);



                        /*
                        Debug.Log("Breakpoint1");
                        RESIZING PYLON NODES
                        
                        Debug.Log(pylonInstance.transform.GetChild(0).gameObject.name);
                        Debug.Log(pylonInstance.transform.GetChild(0).transform.GetChild(0).gameObject.name);
                        pylonInstance.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.localScale =
                            pylonInstance.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.localScale;
                        Transform oldParent = pylonInstance.transform.Find("Pylons");
                        Transform oldParent2 = pylonInstance.transform.Find("Pylons");

                        Transform oldChild = pylonInstance.transform.GetChild(0).transform.GetChild(0).transform.Find("CableNode 1").transform;
                        Transform oldChild2 = oldChild.transform.GetChild(0).transform;
                        //Transform oldChild2 = pylonInstance.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).Find("CableNode 2").transform;


                        pylonInstance.transform.GetChild(0).transform.GetChild(0).transform.Find("CableNode 1").transform.parent = null;

                        pylonInstance.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.parent = null;
                        Debug.Log("Breakout2");
                        // Debug.Log("this is local scale" + pylonInstance.transform.GetChild(0).transform.GetChild(0).transform.Find("CableNode1").transform.localScale);

                        Debug.Log("distance" + distance);
                        oldChild.transform.localScale =  new Vector3(0.17f,0.17f,0.2f);
                        oldChild2.transform.localScale =  new Vector3(0.17f,0.17f,0.2f);



                        oldChild.parent = oldParent;
                        oldChild2.parent = oldParent2;
                        */
                        Debug.Log("Breakpoint3");
    

                       //*******************

                        GameObject pylon = new GameObject("Pylon");
                        
                        //cableInstance.transform.parent = GameObject.Find("Cable").transform;
                        pylonInstance.transform.parent = pylon.transform;
                        pylon.transform.parent = ObjectArray.transform;
                        pylon.layer = LayerMask.NameToLayer("Structure");

                        Debug.Log("Breakpoint 4");
                        //cableNodes.Add(pylonInstance.transform.Find("CableNode 1").gameObject);
                       // cableNodes.Add(pylonInstance.transform.Find("CableNode 2").gameObject);

                    }

                }
            }
        }

        if (!BaseNodeVisuals.mouseIsOver) //Deactivate Column if click elsewhere
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (selectedBaseNode != null)
                {
                    
                    for (int i = 0; i < selectedBaseNode.transform.childCount; i++)
                    {
                        selectedBaseNode.transform.GetChild(i).gameObject.SetActive(false);

                    }
                }
                selectedBaseNode = null;
            }

        }
    }
    #endregion
    private void ChangeParentScale(Transform parent, Vector3 scale)
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in parent)
        {
            child.parent = null;
            children.Add(child);
        }
        parent.localScale = scale;
        foreach (Transform child in children) child.parent = parent;
    }
}


