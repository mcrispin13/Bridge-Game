using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class WinFailState : MonoBehaviour
{
    public GameObject failZone;
    public GameObject failMenu;
    public GameObject midGameMenu;
    public ParticleSystem explosion;
    public GameObject kaboom;
    public AudioSource audioSource;
    float m_MySliderValue;
    private void Start()
    {
        midGameMenu.SetActive(true);
        failMenu.SetActive(false);
        kaboom.SetActive(false);
        m_MySliderValue = 0.1f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Truck")
        {
            Debug.Log("Collision");
            //midGameMenu.SetActive(false);
            //failMenu.SetActive(true);
            explosion.Play();
            CameraShaker.Instance.ShakeOnce(4f, 2.5f, 1f,2f);
            kaboom.SetActive(true);
            audioSource.volume = m_MySliderValue;
            audioSource.Play();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        //NEED TO RESET TRUCKS POSITION BEFORE THIS PROBABLY 
        failMenu.SetActive(false);
        midGameMenu.SetActive(true);

    }
}
