using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endGame : MonoBehaviour
{
    public GameObject areYouSureRestart;
    public GameObject areYouSureQuit;
    public GameObject endGamePanel;
    public GameObject leaderboard;
    //cursor stuff
    public Texture2D cursorTexture;
    public Texture2D defaultTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;
    //score stuff
    int score;
    public GameObject gameManagerObject;
    //namey things
    public Text playerEntryName;
    string playerName;
    public Button enterName;

    private void OnEnable()
    {
        score = gameManagerObject.GetComponent<gameManager>().score;
        //when turned on do these things
        Time.timeScale = 0;
        checkScore(score);
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    

    public void RestartButton()
    {
        endGamePanel.SetActive(false);
        areYouSureRestart.SetActive(true);
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
        endGamePanel.SetActive(false);
        areYouSureQuit.SetActive(true);
    }

    public void QuitGame()
    {
        //exit game when yes for are you sure is clicked
        Application.Quit();
    }

    

    public void noQuit()
    {
        endGamePanel.SetActive(true);
        areYouSureQuit.SetActive(false);
    }

    public void noRestart()
    {
        endGamePanel.SetActive(true);
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

    public void leaderboardClick()
    {
        //show leaderboard
        leaderboard.SetActive(true);
        endGamePanel.SetActive(false);
    }

    public void returnButton()
    {
        leaderboard.SetActive(false);
        endGamePanel.SetActive(true);
    }

    public void checkScore(int score)
    {
        //compare scores
        for (int i = 0; i < 10; i--)
        {
            int temp;
            temp = PlayerPrefs.GetInt("highscore" + i);
            if(score > temp)
            {
                //if score is larger move all other scores down
                for(int h = i; h < 10; h++)
                {
                    PlayerPrefs.SetInt("highscore" + h, PlayerPrefs.GetInt("highscore" + (h - 1)));
                    PlayerPrefs.SetString("scoreName" + h, PlayerPrefs.GetString("scoreName" + (h - 1)));
                }
                PlayerPrefs.SetInt("highscore" + i, score);

                PlayerPrefs.SetString("scoreName" + i, "unknown");
            }
        }

        
    }

    public void onInput()
    {
        enterName.enabled = true;
    }

    public void enteredName()
    {
        playerName =  playerEntryName.text;
    }
}
