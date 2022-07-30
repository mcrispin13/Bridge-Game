using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Material highlight;
    Color opacity;
    // Start is called before the first frame update
    void Start()
    {
        //Material highlight = GetComponent<Material>();
        Color opacity = highlight.color;
    }

    
    void Update()
    {
         
        Mathf.PingPong(opacity.a, 1f);
        Debug.Log(opacity.a);

        if (Input.GetKey(KeyCode.P))
        {
            opacity.a = 0;
        }

        if (Input.GetKey(KeyCode.O))
        {
            opacity.a = 1;
        }
    }
}
