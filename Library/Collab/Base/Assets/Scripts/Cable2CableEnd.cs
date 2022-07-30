using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable2CableEnd : MonoBehaviour
{
    // Start is called before the first frame update
    private FixedJoint fj;

    public GameObject cableEnd;
    // Start is called before the first frame update
    void Start()
    {
        //iterates through every child present in roads 
        cableEnd.AddComponent<FixedJoint>();
        fj = cableEnd.GetComponent<FixedJoint>();

    }
    
    void OnTriggerEnter(Collider collider) {
        
        if(collider.gameObject.tag == "CableEnd")
        {
            //Debug.Log("I'm here bois");
            fj.connectedBody = collider.attachedRigidbody;
        }
    }
}
