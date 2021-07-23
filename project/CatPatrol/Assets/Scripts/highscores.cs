using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;


public class highscores : MonoBehaviour
{

    public List<int> leaderboard;
    public List<string> scoreNames;
    public Text scores;
    //add highscore to player prefs
    private void Start()
    {
        //check if created scores 10 times
        for (int i = 0; i < 10; i++)
        {
            if (!PlayerPrefs.HasKey("highscore" + i))
            {
                PlayerPrefs.SetInt("highscore" + i, 1);
            }
            if (!PlayerPrefs.HasKey("scoreName" + i))
            {
                PlayerPrefs.SetString("scoreName" + i, "Sasquatch");
            }

        }
        //get scores and add to highscore list
        for (int i = 0; i < 10; i++)
        {
            int temp;
            temp = PlayerPrefs.GetInt("highscore" + i);
            leaderboard.Add(temp);
        }

        for (int i = 0; i < 10; i++)
        {
            string temp;
            temp = PlayerPrefs.GetString("scoreName" + i);
            scoreNames.Add(temp);
        }

        //add text to highscoreboard

        for (int i = 0; i < 10; i++)
        {
            scores.text = scores.text + "\n" + leaderboard[i].ToString() + " " + scoreNames[i];
        }

        //just need to add end game stuff to change highscores if i need

    }

    public void updateLeaderboard()
    {
        leaderboard.Clear();
        scoreNames.Clear();
        for (int i = 0; i < 10; i++)
        {
            int temp;
            temp = PlayerPrefs.GetInt("highscore" + i);
            leaderboard.Add(temp);
        }

        for (int i = 0; i < 10; i++)
        {
            string temp;
            temp = PlayerPrefs.GetString("scoreName" + i);
            scoreNames.Add(temp);
        }
    }




}