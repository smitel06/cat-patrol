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
    //journal
    public GameObject journal;

    // Start is called before the first frame update
    void Start()
    {
        //set score
        score = 0;
        //set cursor for mouse
        Cursor.SetCursor(cursorTexture, hotspot, cursorMode);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            if (journal.activeSelf == true)
            {
                journal.SetActive(false);
            }
            else
                journal.SetActive(true);
        }
        //this is to update player position for camera otherwise it would not move
        player.transform.position = player.transform.position;
        mCam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + vertAdjustment, -10);

        //score manager
        scoreText.text = score.ToString();
    }

    public void AddToScore()
    {
        score++;
    }
}
