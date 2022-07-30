using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ExplosionTrigger : MonoBehaviour
{
    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKey("right shift"))
        {
            explosion.Play();
            CameraShaker.Instance.ShakeOnce(4f, 2.5f, 1f,2f);
        }
    }*/
    
    void OnEnable()
    {
        explosion.Play();
        CameraShaker.Instance.ShakeOnce(4f, 2.5f, 1f,2f);
    }
}
