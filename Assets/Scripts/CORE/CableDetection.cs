using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableDetection : MonoBehaviour
{

    List<FixedJoint> fjList = new List<FixedJoint>();

    private FixedJoint fj;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CableStart" || other.tag == "CableEnd")
        {
            fj = gameObject.AddComponent<FixedJoint>();

            {
                fj.connectedBody = other.attachedRigidbody;
                fj.breakForce = 300;
                fj.breakTorque = 300;
            }
        }
    }
    
    //yOU GET A COLLISION BETWEEN THE CABLE START/END AND THE pYLON'S CABLE NODE. 
    //aT THIS POINT

}
