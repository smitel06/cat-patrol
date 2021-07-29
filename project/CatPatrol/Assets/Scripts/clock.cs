using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clock : MonoBehaviour
{
    //this script will be used to run the clock in game
    //in the background will be a timer that when finished will complete game

    //variables
    Text timeText;
    int hoursI;
    int minutesI;
    string hours;
    string minutes;
    //timer
    public float gameLength;
    public float gameTime;
    //clock ticking down
    float timeTickDown;
    float changeTime;
    //gamemanager
    public GameObject gameManager;
    bool endGame;
    //end game
    public GameObject endGameObject;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager.GetComponent<gameManager>().gameMode == 1)
        {
            //set game mode
            endGame = false;
        }
        else
            endGame = true;

        timeText = GetComponent<Text>();
        //set starting clock
        hoursI = 1;
        minutesI = 0;
        //timer
        gameLength = 5f; //5 minutes change this for longer game
        
        //tick for clock
        timeTickDown = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(changeTime < Time.time)
        {
            //down one minute
            minutesI++;
            //reset
            changeTime = Time.time + timeTickDown;
            
        }
        //convert ints to string
        hours = hoursI.ToString();
        //if minutes does not equal zero do this
        //else string = 00
        if (minutesI != 0)
        {
            minutes = minutesI.ToString();
        }
        //hour up and reset minutes
        if(minutesI == 60)
        {
            minutesI = 0;
            minutes = "00";
            if (hoursI != 12)
            {
                hoursI++;
            }
            else
            {
                hoursI = 1;
            }
        }
        //display 0 before number below 10
        if(minutesI < 10)
        {
            minutes = "0" + minutesI.ToString();
        }
        //display clock
        if (hoursI == 12)
        {
            timeText.text = hours + ":" + minutes;
        }
        else
        {
            
            timeText.text = hours + ":" + minutes;
        }

        

        //if clock reaches six end game
        if(hoursI == 6 && endGame)
        {
            timeText.text = "6:00";
            endGameObject.SetActive(true);
            Debug.Log("end game");
        }



    }

    public void setTimer()
    {
        changeTime = Time.time + timeTickDown;
        gameTime = Time.time + (gameLength * 60);
    }


}
