using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PylonJoints : MonoBehaviour
{
    FixedJoint[] joints;

    [SerializeField] private GameObject roads;
    private GameObject pylon1;
    private GameObject pylon2;

    // Start is called before the first frame update
    void Start()
    {
        //iterates through every child present in roads 
        int count = 0;
        foreach( Transform child in transform){
            // count++;
            // Debug.Log("child" + count);
        }
        roads.AddComponent<FixedJoint>();
        roads.AddComponent<FixedJoint>();
        joints = GetComponents<FixedJoint>();

        foreach (FixedJoint joint in joints)
        {
            joint.breakForce = 100f;
            joint.breakTorque = 100f;
            
            joint.enablePreprocessing = false;
        }

    }
    private void Update()
    {
       
    }
    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("sphere collided");
        if (pylon1)
        {

            if (collider.gameObject.tag == "Pylon")
            {

                if (collider.gameObject.name == "Pylon1")
                {
                    joints[0].connectedBody = collider.GetComponent<Rigidbody>();

                    pylon1 = collider.gameObject;
                }

                if (collider.gameObject.name == "Pylon2")
                {
                    joints[1].connectedBody = collider.GetComponent<Rigidbody>();

                    pylon2 = collider.gameObject;
                }
            }
        }
    }
    
    void OnJointBreak(float breakForce) {
        Debug.Log("joint broken!");
        pylon1.GetComponent<Rigidbody>().isKinematic = false;
       pylon2.GetComponent<Rigidbody>().isKinematic = false;
        
    }

    


}
