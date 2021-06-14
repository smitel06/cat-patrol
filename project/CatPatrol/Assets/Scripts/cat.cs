using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cat : MonoBehaviour
{
    public string clickMessage;
    //text object
    public Text catFound;
    //waiting time
    float timeToWait;
    float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        timeToWait = 5.0F;
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

    public void DisplayMessage()
    {
        //set text to click message
        catFound.text = clickMessage;
        //show message for 5 seconds
        catFound.enabled = true;
        //set wait time 
        waitTime = Time.time + timeToWait;
        
    }
}
