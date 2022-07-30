using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Material red;
    [SerializeField] private Material green;

    private MeshRenderer myRend;

    [HideInInspector] public bool currentlySelected = false;
    
    void Start()
    {
        myRend = GetComponent<MeshRenderer>();
        clickMe();
    }

    public void clickMe()
    {
        if (currentlySelected == false)
        {
            myRend.material = red;
        }
        else
        {
            myRend.material = green;
        }
        
    }
}
