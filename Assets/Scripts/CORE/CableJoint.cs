using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableJoint : MonoBehaviour
{

    [SerializeField] private GameObject RoadNode;

    private FixedJoint fj;
    // Start is called before the first frame update
    void Start()
    {
        //iterates through every child present in roads 
        RoadNode.AddComponent<FixedJoint>();
        fj = RoadNode.GetComponent<FixedJoint>();
        

    }
    
    void OnTriggerEnter(Collider collider) {
        
        if(collider.gameObject.tag == "CableEnd" || collider.gameObject.tag == "CableStart")
        {
           // Debug.Log("I'm here bois");
            fj.connectedBody = collider.attachedRigidbody;
            fj.breakForce = 300f;
            fj.breakTorque = 300f;
        }
    }
    
    
    
    
    
    
    
    
}