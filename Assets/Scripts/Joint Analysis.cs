using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointAnalysis : MonoBehaviour
{

    GameObject[] jointsGO;
    FixedJoint[] fjArr;
    bool callOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        jointsGO = GameObject.FindGameObjectsWithTag("RoadJoints");

        for (int i = 0; i < jointsGO.Length; i += 2)
        {
            fjArr[i] = jointsGO[i].GetComponent<FixedJoint>();
        }
        
        
        Debug.Log(fjArr.Length);
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
