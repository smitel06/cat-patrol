using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frank : MonoBehaviour
{
    //frank can end the game real quick
    public Slider visionSlider;
    float maxValue;
    float minValue;
    public float currentValue;
    //gm
    public GameObject gameManager;
    //for messages
    public GameObject screenMessage;
    //end game stuff
    float waitTime;
    float timeToWait;
    bool endGame;
    //other time stuff
    bool tickOn;
    //cursor stuff
    public Texture2D cursorTexture;
    public Texture2D defaultTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;

    // Start is called before the first frame update
    void OnEnable()
    {
        //time to wait until end game runs
        waitTime = 5f;

        

        maxValue = 30;
        minValue = 0;
        currentValue = minValue;

        visionSlider.maxValue = maxValue;
        visionSlider.minValue = minValue;
    }

    // Update is called once per frame
    void Update()
    {
        //set visionslider
        visionSlider.value = currentValue;


        if (!tickOn)
        {
            InvokeRepeating("TickDown", 2.5f, 0.25f / 5);
            tickOn = true;
        }
        


        if(endGame && Time.time < timeToWait)
        { 
            gameManager.SendMessage("endGame"); 
        }

        //he saw you for too long
        if(currentValue >= maxValue)
        {
            screenMessage.SendMessage("ShowText", "Frank found you!");
            endGame = true;
            timeToWait = waitTime + Time.time;
            
        }
    }

    void TickDown()
    {
        currentValue += 0.5f;
    }

    private void OnMouseOver()
    {

        //set cursor for mouse
        Cursor.SetCursor(cursorTexture, hotspot, cursorMode);

        if (Input.GetMouseButtonDown(0))
        {
            clicked();
        }

    }

    void OnMouseExit()
    {
        Cursor.SetCursor(defaultTexture, hotspot, cursorMode);
    }

    void clicked()
    {
        Cursor.SetCursor(defaultTexture, hotspot, cursorMode);
        screenMessage.SendMessage("ShowText", "You scared Frank Off!");
        Destroy(gameObject);
    }



}


