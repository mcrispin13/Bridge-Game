using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Reference: https://www.youtube.com/watch?v=itIh8PYGP7w
public class Gizmo : MonoBehaviour
{
    public float gizmoSize = 0.75f;

    public Color gizmoColor = Color.yellow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }
}
