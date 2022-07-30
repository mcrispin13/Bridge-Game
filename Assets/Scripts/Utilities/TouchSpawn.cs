using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TouchSpawn : MonoBehaviour
{ }
    /*
    public GameObject frame_prefab;
    public GameObject frame_sphere_prefab;
    public GameObject frame_sphere_prefab2;
    public TMP_Text budgetText;
    public GameObject gameOver;
    public int initScore = 1000;
    public Camera   mainCamera;

    private void Start()
    {
        gameOver = GameObject.Find("GameOver");
        //gameOver.SetActive(false);
        budgetText.text = "$"+initScore.ToString();
        
    }

    //Draw and Move Mode. 
    // Update is called once per frame
    void Update()
    {
        
        //responsible for drawing the lines
        if(Input.GetMouseButtonDown(0)) {
            Vector3 touchPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4.1f));
            Vector3 touchPos2 = touchPos + new Vector3(10f, 10f, 10f);
            Debug.Log(touchPos);
            Debug.Log(touchPos2);
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                if (selection.GetComponent<Vertex>())
                {
                    var vertex = Instantiate(frame_prefab, selection.position, Quaternion.identity); //Instantiate 
                    //vertex.GetComponent<MoveRotate>().setSelected();
                    var edgeObject = Instantiate(frame_sphere_prefab, touchPos, Quaternion.identity); //Instantiate 
                    initScore -=10;
                    budgetText.text = "$"+initScore.ToString();
                    var edge = edgeObject.GetComponent<Edge>(); //TODO: Add condition that deactivates this if beyond clamp value
                    edge.SetPoints(selection.GetComponent<Vertex>(),vertex.GetComponent<Vertex>());
                    vertex.GetComponent<MoveRotate>().setSelected();
                    
                    
                    //Parallel side
                    var vertex2 = Instantiate(frame_prefab, selection.position+new Vector3(0f,0.0f,1f), Quaternion.identity); //Instantiate 
                    //frame_prefab is the sphere
                    //frame_sphere_prefab is the cylinder
                     var edgeObject2 = Instantiate(frame_sphere_prefab, touchPos2, Quaternion.identity); //Instantiate 
                     var edge2 = edgeObject2.GetComponent<Edge>(); //Idhu varaikum correct
                    // edge2.SetPoints(selection.GetComponent<Vertex>(),vertex2.GetComponent<Vertex>());
                    // vertex2.GetComponent<MoveRotate>().setSelected();
                    
                    
         
                }
            }


        
        
        }


    }
}
*/
//Based on AM-APPS's video.