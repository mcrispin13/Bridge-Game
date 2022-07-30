using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button cableButton, pylonButton, undoButton;
    bool runOnce = true;

    

    void Start()
    {
        cableButton.interactable = false;
        pylonButton.interactable = false;
    }

    
    void Update()
    {
        if (ItemSlot.bridgeActivated) //THIS IS PERPETUAL, Problematic
        {
            cableButton.interactable = true;
            pylonButton.interactable = true;
        }
        

    }
}
