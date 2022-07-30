using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveRotate : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public float angle;
    private bool selected;
    
    
    public AudioSource source;
    private ModeManager modemanager;
    private void Start()
    {
        //selected = false;
        source = GetComponent<AudioSource>();
        modemanager = GameObject.FindObjectOfType<ModeManager>();


    }

    public void setSelected()
    {
        selected = true;
        Debug.Log("Selected is being set to true");
        if (selected)
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseWorldPos();
        }
    }

    public void disableSelected()
    {
        selected = true;
    }

    private void Update()
    {
        if (selected)
        {
            transform.position = GetMouseWorldPos() + mOffset;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha5)) //THIS IS THE KEY TO BE PRESSED TO STOP DRAWING
        {
            selected = false;
        }
        
    }

    private void OnMouseDown()
   {
       if (modemanager.dragMode||selected)
       {
           selected = false;
           mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
           mOffset = gameObject.transform.position - GetMouseWorldPos();
       }

   }

   private Vector3 GetMouseWorldPos()
   {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
   }

   private void OnMouseDrag()
   {
       if (modemanager.dragMode||selected)
       {
           transform.position = GetMouseWorldPos() + mOffset;
       }
   }

   private void OnCollisionEnter(Collision c){
         source.Play();
         var joint = gameObject.AddComponent<HingeJoint>(); 
         joint.connectedBody = c.rigidbody;
         

    }


    
}
