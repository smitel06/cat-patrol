using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject areYouSureRestart;
    public GameObject areYouSureQuit;
    public GameObject catPaused;
    //cursor stuff
    public Texture2D cursorTexture;
    public Texture2D defaultTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;

    private void OnEnable()
    {
        //when turned on do these things
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void Resume()
    {
        //resume game
        Cursor.SetCursor(defaultTexture, hotspot, cursorMode);
        gameObject.SetActive(false);
        catPaused.SendMessage("Unpause");
    }

    public void RestartButton()
    {
        Cursor.SetCursor(defaultTexture, hotspot, cursorMode);
        areYouSureRestart.SetActive(true);
    }
    public void Restart()
    {
        //restart session
        SceneManager.LoadScene("main");
    }

    public void ExitButton()
    {
        Cursor.SetCursor(defaultTexture, hotspot, cursorMode);
        //exit game
        //show are you sure 
        areYouSureQuit.SetActive(true);
    }

    public void QuitGame()
    {
        //exit game when yes for are you sure is clicked
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Resume();
    }

    public void noQuit()
    {
        Cursor.SetCursor(defaultTexture, hotspot, cursorMode);
        areYouSureQuit.SetActive(false);
    }

    public void noRestart()
    {
        Cursor.SetCursor(defaultTexture, hotspot, cursorMode);
        areYouSureRestart.SetActive(false);
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
