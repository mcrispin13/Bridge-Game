using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GridHighlight : MonoBehaviour
{
    //columns
    public Dropdown dropdown;
    [SerializeField] private LayerMask clickablesLayer;
    
    
    // Start is called before the first frame update
    public GameObject[] col1;
    public GameObject[] col2;
    public GameObject[] col3;
    public GameObject[] col4;
    public GameObject[] col5;
    public GameObject[] col6;
    public GameObject[] col7;
    public GameObject[] col8;
    public GameObject[] col9;
   
    public GameObject[] row1; //Use this for Road

    public GameObject Enablecol1;
    public GameObject Enablecol2;
    public GameObject Enablecol3;
    public GameObject Enablecol4;
    public GameObject Enablecol5;
    public GameObject Enablecol6;
    public GameObject Enablecol7;
    public GameObject Enablecol8;
    public GameObject Enablecol9;
    public GameObject Enablerow1;
    
    
    void Start()
    
    {
        List<GameObject> C1 = col1.Cast<GameObject>().ToList();
        List<GameObject> C2 = col2.Cast<GameObject>().ToList();
        List<GameObject> C3 = col3.Cast<GameObject>().ToList();
        List<GameObject> C4 = col4.Cast<GameObject>().ToList();
        List<GameObject> C5 = col5.Cast<GameObject>().ToList();
        List<GameObject> C6 = col6.Cast<GameObject>().ToList();
        List<GameObject> C7 = col7.Cast<GameObject>().ToList();
        List<GameObject> C8 = col8.Cast<GameObject>().ToList();
        List<GameObject> C9 = col9.Cast<GameObject>().ToList();
        List<GameObject> R1 = row1.Cast<GameObject>().ToList();
        Enablerow1.SetActive(false);
    }
    
    

    // Update is called once per frame
    void Update()
    {
        if (dropdown.value == 2)
        {
            Enablerow1.SetActive(false);
            
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit rayHit;
                
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity,
                    clickablesLayer))
                {
                    //add logic 
                    
                 
                        //Debug.Log( hit.transform.gameObject.name );
                        GameObject buffer = rayHit.transform.gameObject;
                        Debug.Log(rayHit.transform.gameObject.name);
                        if (col1.Contains(buffer))
                        {
                            Enablecol1.SetActive(true);
                            Enablecol2.SetActive(false);
                            Enablecol3.SetActive(false);
                            Enablecol4.SetActive(false);
                            Enablecol5.SetActive(false);
                            Enablecol6.SetActive(false);
                            Enablecol7.SetActive(false);
                            Enablecol8.SetActive(false);
                            Enablecol9.SetActive(false);

                        }

                        else if(col2.Contains(buffer))
                        {
                            Enablecol1.SetActive(false);
                            Enablecol2.SetActive(true);
                            Enablecol3.SetActive(false);
                            Enablecol4.SetActive(false);
                            Enablecol5.SetActive(false);
                            Enablecol6.SetActive(false);
                            Enablecol7.SetActive(false);
                            Enablecol8.SetActive(false);
                            Enablecol9.SetActive(false);
                        }
                        
                        else if(col3.Contains(buffer))
                        {
                            Enablecol1.SetActive(false);
                            Enablecol2.SetActive(false);
                            Enablecol3.SetActive(true);
                            Enablecol4.SetActive(false);
                            Enablecol5.SetActive(false);
                            Enablecol6.SetActive(false);
                            Enablecol7.SetActive(false);
                            Enablecol8.SetActive(false);
                            Enablecol9.SetActive(false);
                        }
                        
                        else if(col4.Contains(buffer))
                        {
                            Enablecol1.SetActive(false);
                            Enablecol2.SetActive(false);
                            Enablecol3.SetActive(false);
                            Enablecol4.SetActive(true);
                            Enablecol5.SetActive(false);
                            Enablecol6.SetActive(false);
                            Enablecol7.SetActive(false);
                            Enablecol8.SetActive(false);
                            Enablecol9.SetActive(false);
                        }
                        
                        else if(col5.Contains(buffer))
                        {
                            Enablecol1.SetActive(false);
                            Enablecol2.SetActive(false);
                            Enablecol3.SetActive(false);
                            Enablecol4.SetActive(false);
                            Enablecol5.SetActive(true);
                            Enablecol6.SetActive(false);
                            Enablecol7.SetActive(false);
                            Enablecol8.SetActive(false);
                            Enablecol9.SetActive(false);
                        }
                        
                        else if(col6.Contains(buffer))
                        {
                            Enablecol1.SetActive(false);
                            Enablecol2.SetActive(false);
                            Enablecol3.SetActive(false);
                            Enablecol4.SetActive(false);
                            Enablecol5.SetActive(false);
                            Enablecol6.SetActive(true);
                            Enablecol7.SetActive(false);
                            Enablecol8.SetActive(false);
                            Enablecol9.SetActive(false);
                        }
                        
                        else if(col7.Contains(buffer))
                        {
                            Enablecol1.SetActive(false);
                            Enablecol2.SetActive(false);
                            Enablecol3.SetActive(false);
                            Enablecol4.SetActive(false);
                            Enablecol5.SetActive(false);
                            Enablecol6.SetActive(false);
                            Enablecol7.SetActive(true);
                            Enablecol8.SetActive(false);
                            Enablecol9.SetActive(false);
                        }
                        
                        else if(col8.Contains(buffer))
                        {
                            Enablecol1.SetActive(false);
                            Enablecol2.SetActive(false);
                            Enablecol3.SetActive(false);
                            Enablecol4.SetActive(false);
                            Enablecol5.SetActive(false);
                            Enablecol6.SetActive(false);
                            Enablecol7.SetActive(false);
                            Enablecol8.SetActive(true);
                            Enablecol9.SetActive(false);
                        }

                        else
                        {
                            Enablecol1.SetActive(false);
                            Enablecol2.SetActive(false);
                            Enablecol3.SetActive(false);
                            Enablecol4.SetActive(false);
                            Enablecol5.SetActive(false);
                            Enablecol6.SetActive(false);
                            Enablecol7.SetActive(false);
                            Enablecol8.SetActive(false);
                            Enablecol9.SetActive(true);
                        }
                        
                        

                    
                }

            }
        }
        
        else if (dropdown.value == 1)
        {
            Enablecol1.SetActive(false);
            Enablecol2.SetActive(false);
            Enablecol3.SetActive(false);
            Enablecol4.SetActive(false);
            Enablecol5.SetActive(false);
            Enablecol6.SetActive(false);
            Enablecol7.SetActive(false);
            Enablecol8.SetActive(false);
            Enablecol9.SetActive(false);
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit rayHit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity,
                    clickablesLayer))
                {
                    //add logic 


                    //Debug.Log( hit.transform.gameObject.name );
                    GameObject buffer = rayHit.transform.gameObject;
                    Debug.Log(rayHit.transform.gameObject.name);
                    if (row1.Contains(buffer))
                    {
                        Enablerow1.SetActive(true);
                    }
                 
                }
            }
        }
        else
        {
            //Do nothing (Hopefully)
        }
    }
}
