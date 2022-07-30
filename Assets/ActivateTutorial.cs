using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTutorial : MonoBehaviour
{
    Animation levitateAnim;
    Animator levAnim;
    public GameObject tutorialUI, title, startButton, TutorialButton;


    void Start()
    {
        levAnim = GetComponent<Animator>();
    }

    public void StartTutorial()
    {
        levAnim.enabled = true;
        

        title.SetActive(false);
        startButton.SetActive(false);
        TutorialButton.SetActive(false);

       Invoke( "tutorialUI.SetActive(true)", 1.5f);
    }
}
