using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructModeToggle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject frame;
    [SerializeField] public GameObject road;
    [SerializeField] public Dropdown dropdownMenu;
    void Start()
    {
        dropdownMenu.onValueChanged.AddListener(delegate
        {
            dropdownMenuchanged(dropdownMenu);
        });

    }
    
    public void dropdownMenuchanged(Dropdown sender)
    {
        if (sender.value == 0)
        {
            frame.SetActive(true);
            road.SetActive(false);
        }
        else
        {
            frame.SetActive(false);
            road.SetActive(true);
        }
    }
}
