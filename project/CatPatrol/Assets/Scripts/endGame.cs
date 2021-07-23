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
    public GameObject confirmName;
    public GameObject beatenHighscore;
    bool updateScores;
    int scoreBeaten;


    public void OnEnable()
    {
        score = gameManagerObject.GetComponent<gameManager>().score;
        //when turned on do these things
        Time.timeScale = 0;
        checkScore(score);
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
        Cursor.SetCursor(defaultTexture, hotspot, cursorMode);
        //show leaderboard
        leaderboard.SetActive(true);
        endGamePanel.SetActive(false);
    }

    public void returnButton()
    {

        Cursor.SetCursor(defaultTexture, hotspot, cursorMode);
        leaderboard.SetActive(false);
        endGamePanel.SetActive(true);
    }

    public void checkScore(int score)
    {
        //compare scores
        for (int i = 0; i < 10; i++)
        {
            int temp;
            temp = PlayerPrefs.GetInt("highscore" + i);
            if (score >= temp)
            {

                //get name and show input field
                endGamePanel.SetActive(false);
                beatenHighscore.SetActive(true);
                scoreBeaten = i;

                return;
            }
            
        }

        
    }

    public void onInput()
    {
        Debug.Log("input string!");
        confirmName.SetActive(true);
    }

    public void enteredName()
    {
        playerName =  playerEntryName.text;
        beatenHighscore.SetActive(false);
        updateScores = true;
        

    }

    private void Update()
    {
        if(updateScores)
        {

            int previousScore = PlayerPrefs.GetInt("highscore" + scoreBeaten);
            string previousName = PlayerPrefs.GetString("scoreName" + scoreBeaten);

            //swap previous with a holder then set previous then set prefs\

            //if score is larger move all other scores down
            for (int h = scoreBeaten + 1; h < 10; h++)
            {
                int holder = previousScore;
                string holderName = previousName;
                previousScore = PlayerPrefs.GetInt("highscores" + h);
                previousName = PlayerPrefs.GetString("scoreName" + h);
                PlayerPrefs.SetInt("highscore" + h, holder);
                PlayerPrefs.SetString("scoreName" + h, holderName);
                
                
            }
            PlayerPrefs.SetInt("highscore" + scoreBeaten, score);
            PlayerPrefs.SetString("scoreName" + scoreBeaten, playerName);
            updateScores = false;
            leaderboard.SetActive(true);
            leaderboard.SendMessage("updateLeaderboard");

            updateScores = false;
        }
    }
}
