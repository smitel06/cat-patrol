using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class catFoundText : MonoBehaviour
{
    //used to control text when finding a cat

    //text object
    public Text catFound;
    //waiting time
    float timeToWait;
    float waitTime;



    // Start is called before the first frame update
    void Start()
    {
        timeToWait = 2.5F;
    }

    // Update is called once per frame
    void Update()
    {
        //checks timer
        if (Time.time > waitTime)
        {
            //turn off message
            catFound.enabled = false;

        }
    }

    public void ShowText(string clickMessage)
    {
        //set text to click message
        catFound.enabled = true;
        catFound.text = clickMessage;
        //set wait time 
        waitTime = Time.time + timeToWait;
    }
}

