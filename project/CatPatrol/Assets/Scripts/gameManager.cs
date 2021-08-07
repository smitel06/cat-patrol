using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;
    //gameobjects
    public GameObject player;
    public GameObject mCam;
    //cam stuff
    public float vertAdjustment;
    //score stuff
    public Text scoreText;
    public int score;
    
    //pause menu
    public GameObject pauseMenu;
    public GameObject catParent;
    public GameObject hiddenCatParent;
    //gamemode selector
    //use an int
    public int gameMode;
    //tutorial
    public GameObject tutorial;
    //camera shake
    public bool cameraShake;
    //multiplier
    int multiplier;
    public bool frenzyBuff;
    public Text multiplierText;
    //cats left
    public Text catsLeftText;
    public int catsLeft;
    public GameObject endGameObject;



    // Start is called before the first frame update
    void Start()
    {
        catsLeft = 31;
        gameMode = PlayerPrefs.GetInt("mode");
        //set score
        score = 0;
        //set cursor for mouse
        Cursor.SetCursor(cursorTexture, hotspot, cursorMode);
        
        if(gameMode == 1)
        {
            Debug.Log("working new mode selected");
        }

        multiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(catsLeft == 0)
        {
            endGame();
        }

        if (!frenzyBuff)
        {
            multiplierText.enabled = false;
            multiplier = 1;
        }
        else if (frenzyBuff && multiplier == 1)
            multiplier = 2;
        
        if(frenzyBuff)
        {
            multiplierText.enabled = true;
            multiplierText.text = "Multiplier x" + multiplier;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf == false && tutorial == null)
        {
            //open pause menu
            pauseMenu.SetActive(true);
            catParent.SendMessage("Pause");
            
        }


        
        //this is to update player position for camera otherwise it would not move
        player.transform.position = player.transform.position;
        if (!cameraShake)
        {
            mCam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + vertAdjustment, -10);
        }

        //score manager
        scoreText.text = score.ToString();
    }

    public void AddToScore()
    {
        score += (1 * multiplier);

        if(frenzyBuff)
        {
            
            multiplier++;
        }
    }

    public void catsLeftTaken()
    {
        catsLeft -= 1;
        catsLeftText.text = catsLeft.ToString();
    }    

    public void endGame()
    {
        endGameObject.SetActive(true);
    }
}
