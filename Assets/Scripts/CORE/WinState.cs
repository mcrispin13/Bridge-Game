using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : MonoBehaviour
{

    // I KNOW THIS SHOULD BE IN THE SAME SCRIPT THAT WE DETECT ALL COLLISIONS IN BUT I'M TOO TIRED 

    public GameObject winMenu;
    public GameObject midGameMenu;
    public GameObject winNotify;
    
    GameObject truck;
    Rigidbody truckRB;

    private void Start()
    {
        truck = GameObject.FindGameObjectWithTag("Truck");
        truckRB = truck.GetComponent<Rigidbody>();
        winNotify.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Truck")
        {
            truckRB.velocity = Vector3.zero;
            truckRB.angularVelocity = Vector3.zero;
            Debug.Log("Win");
            winNotify.SetActive(true);
        }
    }
}
