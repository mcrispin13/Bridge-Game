using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ClickAndDestroy : MonoBehaviour
{
    [SerializeField] public Button deleteButton;
    [SerializeField] public Button pylonButton;
    [SerializeField] public Button cableButton;

    private bool deleteMode;

    public void activateDelete()
    {
        deleteMode = true;
        deleteButton.GetComponent<Image>().color = Color.green;
        cableButton.GetComponent<Image>().color = Color.white;
        pylonButton.GetComponent<Image>().color = Color.white;
    }
    
    public void pylon()
    {
        GetComponent<NewMain>().enabled = true;
        cableButton.GetComponent<Image>().color = Color.white;
        pylonButton.GetComponent<Image>().color = Color.green;
        deleteButton.GetComponent<Image>().color = Color.white;
        deleteMode = false;
        deleteButton.interactable = true;
    }
    
    public void cable()
    {
        GetComponent<NewMain>().enabled = true;
        pylonButton.GetComponent<Image>().color = Color.white;
        cableButton.GetComponent<Image>().color = Color.green;
        deleteButton.GetComponent<Image>().color = Color.white;
        deleteMode = false;
        deleteButton.interactable = true;
    }
    
    
    
    
    
    
    
    // Update is called once per frame
    void Update()
    {
        if (deleteMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    BoxCollider bc = hit.collider as BoxCollider;
                    SphereCollider sc = hit.collider as SphereCollider;
                    if (bc != null)
                    {
                        Destroy(bc.gameObject);
                    }
                    if (sc != null)
                    {
                        Destroy(sc.gameObject);
                    }
                }
            }
        }
    }
}