using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class BeginningAnimation : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject tutorial;
    public AnimationClip sweepingAnimation;
    
   
    // Start is called before the first frame update
    void Start()
    {
        Invoke("TurnOnMainMenu", 6.7f); 
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void TurnOnMainMenu()
    {
       
        mainMenu.SetActive(true);
    }

    public void LoadTableScene()
    {
        
        SceneManager.LoadScene("Table Scene");

    }

    public void LoadTutorial()
    {
        
        tutorial.SetActive(true);
    }
}
