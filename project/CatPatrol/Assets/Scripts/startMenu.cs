using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{

    public GameObject startMenuPanel;
    public GameObject areYouSureQuit;
    public GameObject selectGameMode;
    //cursor stuff
    public Texture2D cursorTexture;
    public Texture2D defaultTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;

    private void Start()
    {
        //when turned on do these things
        Time.timeScale = 0;
    }

    

    public void StartGame()
    {
        //resume game
        selectGameMode.SetActive(true);
        startMenuPanel.SetActive(false);
    }

   

    public void ExitButton()
    {
        //exit game
        //show are you sure 
        areYouSureQuit.SetActive(true);
    }

    public void QuitGame()
    {
        //exit game when yes for are you sure is clicked
        Application.Quit();
    }

    public void noQuit()
    {
        areYouSureQuit.SetActive(false);
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

    public void highScores()
    {
        //show highscores to player

    }

    public void ReturnButton()
    {
        //return to main menu
        Cursor.SetCursor(defaultTexture, hotspot, cursorMode);
        selectGameMode.SetActive(false);
        startMenuPanel.SetActive(true);
    }

    public void normalSelect()
    {
        //selected normal game type with time constraints
        PlayerPrefs.SetInt("mode", 0);
        SceneManager.LoadScene("main");
    }

    public void freeplaySelect()
    {
        //no timer do as you like
        PlayerPrefs.SetInt("mode", 1);
        SceneManager.LoadScene("main");

    }
}
