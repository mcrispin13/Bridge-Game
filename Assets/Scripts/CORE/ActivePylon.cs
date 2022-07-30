using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePylon : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnJointBreak(float breakForce) {
        Debug.Log("joint broken!");
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
