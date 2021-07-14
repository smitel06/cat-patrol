using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject areYouSure;
    public GameObject catPaused;

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
        
        gameObject.SetActive(false);
        catPaused.SendMessage("Unpause");
    }

    public void Restart()
    {
        //restart session
        SceneManager.LoadScene("main");
    }

    public void ExitButton()
    {
        //exit game
        //show are you sure 
        areYouSure.SetActive(true);
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
        areYouSure.SetActive(false);
    }
}
