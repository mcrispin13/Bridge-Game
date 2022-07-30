using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class UnityLineRendererTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject go1;
    public GameObject go2;
    // Doesn't need public GameObject parent;
    LineRenderer l;
    void Start()
    {
        l = gameObject.AddComponent<LineRenderer>();
        //l.transform.parent = parent.transform;
        //parent.AddComponent<BoxCollider>();
        //parent.AddComponent<Rigidbody>();

    }



    // Update is called once per frame
    void Update()
    {
        //TODO: Add a joint between the two gameobjects
        List<Vector3> pos = new List<Vector3>();
        pos.Add(go1.transform.position);
        pos.Add(go2.transform.position);
        l.startWidth = 0.1f;
        l.endWidth = 0.1f;
        l.SetPositions(pos.ToArray());
        l.useWorldSpace = true;
    }
}