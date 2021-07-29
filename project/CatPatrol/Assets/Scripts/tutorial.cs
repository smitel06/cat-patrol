using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    public GameObject watch;
    //cursor stuff
    public Texture2D cursorTexture;
    public Texture2D defaultTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;
    //tutorial go
    public GameObject tutorialScreen;
    //cat parent
    public GameObject catParent;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clicked()
    {
        //start timer
        watch.SendMessage("setTimer");
        //allow cats to be clicked
        catParent.SendMessage("Unpause");
        //starts the game
        Time.timeScale = 1;
        Cursor.SetCursor(defaultTexture, hotspot, cursorMode);
        Destroy(tutorialScreen);
    }

    public void mouseOver()
    {
        //set cursor for mouse
        Cursor.SetCursor(cursorTexture, hotspot, cursorMode);
    }

    public void mouseExit()
    {
        Cursor.SetCursor(defaultTexture, hotspot, cursorMode);
    }
}