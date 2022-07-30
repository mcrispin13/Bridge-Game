using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMode : MonoBehaviour
{
    GameObject[] BridgeComponents;
    Rigidbody[] RBelements;
    GameObject truck;
    Rigidbody truckRB;

    public AudioSource beepbeep;

    public static bool truckDriving;

    // Start is called before the first frame update
    void Start()
    {
        truck = GameObject.FindGameObjectWithTag("Truck");
        truckRB = truck.GetComponent<Rigidbody>();

        




        //BridgeComponents = new GameObject[26]; //This is hard coded, doesn't allow us to scale the bridge
 
        //BridgeComponents = GameObject.FindGameObjectsWithTag("BridgeComponent");
        //RBelements = new Rigidbody[BridgeComponents.Length];

        /*for(int i = 0; i< BridgeComponents.Length; i++)
        {
            RBelements[i] = BridgeComponents[i].GetComponent<Rigidbody>();
        }*/

        truckDriving = false;

    }

    public void PlayModeStart()
    {
        truckDriving = true;
        beepbeep.Play();

        foreach (GameObject bridgeComp in GameObject.FindGameObjectsWithTag("BridgeComponent"))
        {
            bridgeComp.GetComponent<Rigidbody>().useGravity = true;
        }

        //THE CODE BELOW SHOULD BE DONE IN NODE MANAGER FOR EFFICIENCIES SAKE

        foreach (GameObject cableNode in GameObject.FindGameObjectsWithTag("CableNode"))

        {
            MeshRenderer rend = cableNode.GetComponent<MeshRenderer>();
            rend.enabled = false;

            BoxCollider BC = cableNode.GetComponent<BoxCollider>();
            BC.enabled = false;
        }

        foreach (GameObject baseNode in GameObject.FindGameObjectsWithTag("BaseNode"))
        {
            MeshRenderer rend = baseNode.GetComponent<MeshRenderer>();
            rend.enabled = false;

            BoxCollider BC = baseNode.GetComponent<BoxCollider>();
            BC.enabled = false;
        }


    }
    private void Update()
    {
        if (truckDriving)
        {
            Vector3 v = truckRB.velocity;
            v.x = 1.5f;
            truckRB.velocity = v;
        }
        
        // Debug.Log(truckDriving);
    }

}
