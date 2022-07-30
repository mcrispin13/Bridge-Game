using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 


public class BaseNode : MonoBehaviour
{
    GameObject selectedBaseNode;
    public GameObject pylonPrefab;
    
    

    // Update is called once per frame
    void Update()
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
                        if(selectedBaseNode == null)
                        {
                            Debug.Log("BaseNode Selected");
                            selectedBaseNode = rayHit.collider.gameObject;

                            for (int i = 0; i < selectedBaseNode.transform.childCount; i++)
                            {
                                selectedBaseNode.transform.GetChild(i).gameObject.SetActive(true);
                            }
                        }

                        if(selectedBaseNode != null)
                        {
                            GameObject previousBaseNode = selectedBaseNode;
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
                                    Instantiate(pylonPrefab, selectedBaseNode.transform.position, Quaternion.identity) as GameObject;

                        float distance = Vector3.Distance(selectedBaseNode.transform.position, selectedVertNode.transform.position) - 1;

                        pylonInstance.transform.localScale += new Vector3(0, distance, 0);

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
}
