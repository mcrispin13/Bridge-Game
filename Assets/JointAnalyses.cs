using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JointAnalyses : MonoBehaviour
{

    GameObject[] jointsGO, textPanels;
    Text[] texts;
    FixedJoint[] fjArr;
    GameObject[] colorPanels;
    RawImage[] colorBackgrounds;

    public FixedJoint diagnostic1, diagnostic2, diagnostic3;
    bool callOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        jointsGO = new GameObject[17];
        textPanels = new GameObject[9];
        fjArr = new FixedJoint[9];
        texts = new Text[9];

        

        jointsGO = GameObject.FindGameObjectsWithTag("RoadJoints");

        int j = 0;
        for (int i = 1; i < 18; i = i+ 2)
        {
            fjArr[j] = jointsGO[i].GetComponent<FixedJoint>();
            j++;
        }

        System.Array.Reverse(fjArr);

        textPanels = GameObject.FindGameObjectsWithTag("AnalysisPanel");
        
        for (int i = 0; i < textPanels.Length; i++)
        {
            texts[i] = textPanels[i].GetComponent<Text>();
        }
    }
    void StrategicDebugs()
    {
        Debug.Log("Joint1: " + diagnostic1.currentForce.y.ToString());
        Debug.Log("Joint2: " + diagnostic2.currentForce.y.ToString());
        Debug.Log("JOint3: " + diagnostic3.currentForce.y.ToString());

    }
    void DisplayText()
    {
        for(int i = 0; i < 9; i++)
        {
            texts[i].text = 
            fjArr[i].currentForce.y.ToString();
        }
    }

    void UpdateColor()
    {
        colorPanels = new GameObject[9];
        colorBackgrounds = new RawImage[9];
        for (int i = 0; i < colorPanels.Length; i++)
        {
            colorPanels[i] = textPanels[i].transform.parent.gameObject;
            colorBackgrounds[i] = colorPanels[i].GetComponent<RawImage>();
            
            if(fjArr[i].currentForce.y <100 && fjArr[i].currentForce.y > -100)
            {
                colorBackgrounds[i].color = Color.green;
            }

            else if ((fjArr[i].currentForce.y > 100 && fjArr[i].currentForce.y < 200 )
                || (fjArr[i].currentForce.y < -100 && fjArr[i].currentForce.y > -200))
            {
                colorBackgrounds[i].color = Color.yellow;
            }
            else if ((fjArr[i].currentForce.y > 200 || fjArr[i].currentForce.y <-200))
            {
                colorBackgrounds[i].color = Color.red;
            }
        }

        

    }
    // Update is called once per frame
    void Update()
    {
        DisplayText();
        UpdateColor();
        StrategicDebugs();
    }
}
