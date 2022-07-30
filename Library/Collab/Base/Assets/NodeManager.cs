using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeManager : MonoBehaviour
{
    GameObject selectedBaseNode;
    public GameObject pylonPrefab, cablePrefab;

    public List<GameObject> cableNodes;

    public TMP_Text budgetText; //DO THIS IN A MANAGER SCRIPT
    public int initBudget;
    public int pylonPrice, cablePrice;
    public GameObject overBudgetText;

    Vector3[] points2;
    Vector3[] points;
    Vector3 buffer, emptyPos;

    Renderer rend, rend2;
    GameObject[] BaseNodes;

    public static bool cableMode, pylonMode;

    // Start is called before the first frame update
    void Start()
    {
        emptyPos = new Vector3(0f, 0f, 0f);
        buffer = new Vector3(0, 0, 2.5f);
        points2 = new Vector3[2];
        points = new Vector3[2];
        initBudget = 1000;
        pylonPrice = 100;
        cablePrice = 75;
        budgetText.text = "$" + initBudget.ToString();

        GameObject[] cableNodesArr = GameObject.FindGameObjectsWithTag("CableNode");
        BaseNodes = GameObject.FindGameObjectsWithTag("BaseNode");
        cableNodes.AddRange(cableNodesArr);
        
    }

    // Update is called once per frame
    void Update()
    {
        budgetText.text = "$" + initBudget.ToString();
        ManageBaseNodes();
        ManageCableNodes();

        Debug.Log(cableNodes.Count);
        if(initBudget == 0 || initBudget < 0)
        {
            overBudgetText.SetActive(true);
        }
        else
        {
            overBudgetText.SetActive(false);
        }
           
    }

    private void ManageCableNodes()
    {
        if (CableNodeVis.mouseIsOver) // Mouse over is a monobehavior, makes for inneficient calling
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
                            Debug.Log("First logic");
                            points[0] = rayHit.collider.gameObject.transform.position;
                            points2[0] = rayHit.collider.gameObject.transform.position; // The joints breaking is whats causing the second cable connection to be weird, talk to jude about this. 
                        }
                        //.position + new Vector3(0.0f, 0.0f, 1f));
                        else if (points[0] != emptyPos)
                        {
                            Debug.Log("SecondLogic");
                            points[1] = rayHit.collider.gameObject.transform.position;
                            points2[1] = rayHit.collider.gameObject.transform.position; //PUTTING THE CABLES IN THE SAME PLACE 


                            GameObject cableInstance =
                            Instantiate(cablePrefab, rayHit.collider.gameObject.transform.position, Quaternion.identity) as GameObject;

                            cableInstance.transform.GetChild(0).gameObject.transform.position = points[0];
                            cableInstance.transform.GetChild(1).gameObject.transform.position = points[1]; // + buffer;

                            GameObject cableInstance2 =
                                Instantiate(cablePrefab, rayHit.collider.gameObject.transform.position, Quaternion.identity) as GameObject;
                            
                            cableInstance2.transform.GetChild(0).gameObject.transform.position = points2[0];
                            cableInstance2.transform.GetChild(1).gameObject.transform.position = points2[1];// + buffer;

                            initBudget = initBudget - cablePrice;

                            GameObject cable = new GameObject("Cable");
                            //cableInstance.transform.parent = GameObject.Find("Cable").transform;
                            cableInstance.transform.parent = cable.transform;
                            cableInstance2.transform.parent = cable.transform;
                            cable.tag = "CableTag";
                            cable.layer = LayerMask.NameToLayer("Structure");
                            //cable.transform.parent = ObjectArray.transform;

                            //                            points.Clear();
                            //                          points2.Clear();
                            points[0] = emptyPos;
                            points[1] = emptyPos;
                            points2[0] = emptyPos;
                            points2[1] = emptyPos;

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

                        float distance = Vector3.Distance(selectedBaseNode.transform.position, selectedVertNode.transform.position) - 1;
                        float pylonCost = pylonPrice * distance;

                        initBudget = (int)(initBudget - pylonCost);

                        pylonInstance.transform.localScale += new Vector3(0, distance, 0);

                        cableNodes.Add(pylonInstance.transform.GetChild(3).gameObject);
                        cableNodes.Add(pylonInstance.transform.GetChild(5).gameObject);

                        

                        GameObject pylon = new GameObject("Pylon");
                        //cableInstance.transform.parent = GameObject.Find("Cable").transform;
                        pylonInstance.transform.parent = pylon.transform;
                        //pylon.transform.parent = ObjectArray.transform;
                        pylon.layer = LayerMask.NameToLayer("Structure");
                    }
                }
            }
        }

        if (!BaseNodeVisuals.mouseIsOver)
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

    public void activateCable()
    {
        foreach(GameObject cableNode in cableNodes)
        {

            MeshRenderer rend = cableNode.GetComponent<MeshRenderer>();
            rend.enabled = true;
            //DO THIS WITH A SWITCH CASE 
        }
        foreach (GameObject baseNode in BaseNodes)
        {
            baseNode.transform.gameObject.SetActive(false);
        }

        cableMode = true;
        pylonMode = false;

    }
    //switch to drawing pylons
    public void activatePylon()
    {
        foreach (GameObject cableNode in cableNodes)                //DO THIS WITH A SWITCH CASE
        {
            MeshRenderer rend = cableNode.GetComponent<MeshRenderer>();
            rend.enabled = false;
        }
        foreach (GameObject BaseNode in BaseNodes)
        {
            BaseNode.transform.gameObject.SetActive(true);
        }
        cableMode = false;
        pylonMode = true;
    }
}


