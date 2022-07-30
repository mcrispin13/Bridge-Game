using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenJoint : MonoBehaviour
{

    FixedJoint fj;
    private void Start()
    {
        fj = GetComponent<FixedJoint>();
    }
    private void Update()
    {
      // Debug.Log( fj.currentForce);
    }
    /*private void OnJointBreak(float breakForce)
    {
       
        Debug.Log(gameObject.name + "'s joint broke with :" + breakForce + "force");
    }*/

}
