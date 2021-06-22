﻿using System.Collections;
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
    float gameLength;
    float gameTime;
    //clock ticking down
    float timeTickDown;
    float changeTime;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();
        //set starting clock
        hoursI = 12;
        minutesI = 0;
        //timer
        gameLength = 5f; //5 minutes change this for longer game
        gameTime = Time.time + (gameLength * 60);
        //tick for clock
        timeTickDown = 1;
        changeTime = Time.time + timeTickDown;
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
        timeText.text = hours + ":" + minutes + "pm";

        //timer and tick down for clock
        if(gameTime < Time.time)
        {
            Debug.Log("end game");
        }



    }
}