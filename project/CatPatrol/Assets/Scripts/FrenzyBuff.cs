﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FrenzyBuff : MonoBehaviour
{
    public Slider buffSlider;
    float maxValue;
    float minValue;
    public float currentValue;
    bool tickDown;
    bool buffOn;
    //other ui stuff
    public Text frenzyText;
    public GameObject gameManager;
    public GameObject cam;
    //multi stuff
    public Text multiplierText;

    // Start is called before the first frame update
    void Start()
    {
        tickDown = true;
        maxValue = 100;
        minValue = 0;
        currentValue = 0;

        //set slider values
        buffSlider.maxValue = maxValue;
        buffSlider.minValue = minValue;
        buffSlider.value = currentValue;
    }

    private void Update()
    {
        buffSlider.value = currentValue;

        //every second buff is over 0 tick down 1
        if (currentValue > minValue && tickDown && !buffOn)
        {
            CancelInvoke();
            InvokeRepeating("TickDown", 3.0f, 1.0f);
            tickDown = false;
        }
        else if (currentValue <= 0)
        {
            gameManager.GetComponent<gameManager>().frenzyBuff = false;

            CancelInvoke();
            currentValue = 0;
        }

        if (currentValue > 100)
        {
            currentValue = 100;
        }

        if (currentValue == 100)
        {
            buffOn = true;

            buffed();
            
        }
        
        if(buffOn && currentValue == 0)
        {
            CancelInvoke();
            buffOn = false;
            tickDown = true;
        }

        if(buffOn)
        {
            gameManager.GetComponent<gameManager>().frenzyBuff = true;
            gameManager.GetComponent<gameManager>().cameraShake = true;
            cam.GetComponent<screenShake>().shakeDuration = 1f;
        }
        else
        {
            gameManager.GetComponent<gameManager>().frenzyBuff = false;
            gameManager.GetComponent<gameManager>().cameraShake = false;
            
        }
        

    }

    //add 10 to buff when cat is found
    public void addValue()
    {
        CancelInvoke();
        tickDown = true;
        currentValue += 30;
    }

    public void TickDown()
    {
        currentValue -= 1f;
    }

    public void buffed()
    {
        gameManager.GetComponent<gameManager>().frenzyBuff = true;
        gameManager.GetComponent<gameManager>().cameraShake = true;
        cam.GetComponent<screenShake>().shakeDuration = 30f;

        currentValue -= 1.5f;
        Debug.Log("buffed!");
        
        //character is in a cat frenzy
        InvokeRepeating("TickDown", 0f, 0.12f);
        InvokeRepeating("buffFeedback", 0f, 0.25f);
    }

    public void buffFeedback()
    {
        //pulsating text
        if (frenzyText.fontSize == 35)
        {
            for (int i = 0; i < 7; i++)
            {
                frenzyText.fontSize++;
                multiplierText.fontSize++;
            }
        }
        else
        {
            frenzyText.fontSize = 35;
            multiplierText.fontSize = 35;
        }
        

    }
    
    public void rainingCats()
    {
        //make it rain cats on wanda until frenzy ends
    }
}
