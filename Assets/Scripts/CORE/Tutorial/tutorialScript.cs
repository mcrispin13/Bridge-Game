using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject tutorialpanels;
    [SerializeField] public GameObject IntroPane;
    [SerializeField] public GameObject RoadPanel;
    [SerializeField] public GameObject pylonPanel;
    [SerializeField] public GameObject cablePanel;
    
    [SerializeField] public GameObject cableButton;
    [SerializeField] public GameObject pylonButton;
    [SerializeField] public GameObject roadButton;
    [SerializeField] public GameObject startButton;
    void Start()
    {
        
    }

    public GameObject cursor;

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("Start"))
        {
            cursor.GetComponent<Animator>().Play("pylonButtonClick");
        }
        if (Input.GetButtonDown("Continue1"))
        {
            cursor.GetComponent<Animator>().Play("DragRoad");
        }
        if (Input.GetButtonDown("Continue2"))
        {
            cursor.GetComponent<Animator>().Play("buildPylon");
        }
        if (Input.GetButtonDown("Continue3"))
        {
            cursor.GetComponent<Animator>().Play("cableConnect");
        }*/
        
    }
    //while road collider hsnt triggered something don't go to next
    //while(both colliders haven't touched) {don't go to next}
    //while (2 cable colliders not colliding intersection collider) don't go to next

    public void startBuilding()
    {
        IntroPane.SetActive(false);
        pylonButtonAnimation();
    }
    
    public void pylonButtonAnimation()
    {
        //Text appear
        cursor.GetComponent<Animator>().Play("pylonButtonClick"); 
    }

    public void DragRoad()
    {
        cursor.GetComponent<Animator>().enabled = false;
        RoadPanel.SetActive(true);
    }
    
    public void startAnimation()
    {
        RoadPanel.SetActive(false);
        cursor.GetComponent<Animator>().Play("DragRoad");
    }
    
    public void buildPylonPanelenable()
    {
        cursor.GetComponent<Animator>().enabled = false;
        pylonPanel.SetActive(true);
    }
    
    public void pylonBuildAnimation()
    {
        pylonPanel.SetActive(false);
        cursor.GetComponent<Animator>().Play("buildPylon");
    }

    public void cablePanelenable()
    {
        
        cablePanel.SetActive(true);
    }

    public void cableAnimation()
    {
        cablePanel.SetActive(false);
        cursor.GetComponent<Animator>().Play("cableConnect");
    }
    
    public void stopAnimation()
    {
        cursor.GetComponent<Animator>().enabled = false;
    }
    
}
