using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour , IDropHandler
{
    public static bool bridgeActivated = false;
    private bool bridgeSoundPlayed = false;
    public AudioSource bridgeConstruction;


	[SerializeField] public GameObject panel1;

	[SerializeField] public GameObject cursorobject;
	
	[SerializeField] private GameObject gameObject;

	[SerializeField] private GameObject roadUI;

	[SerializeField] private GameObject itemSlot;

	[SerializeField] private GameObject bridgeGlow;

	[SerializeField] public GameObject step2;
    public void OnDrop(PointerEventData eventData) {
    	Debug.Log("OnDrop");
        bridgeActivated = true;

        if (!bridgeSoundPlayed)
        {
            bridgeConstruction.Play();

            Debug.Log("Soundplayed");
            bridgeSoundPlayed = true;
        }


    	gameObject.SetActive(true);
    	roadUI.SetActive(false);
    	itemSlot.SetActive(false);
		itemSlot.SetActive(false);
    	bridgeGlow.SetActive(false);
        cursorobject.GetComponent<Animator>().Play("pylonButtonClick");
		step2.SetActive(true);

    }
}

