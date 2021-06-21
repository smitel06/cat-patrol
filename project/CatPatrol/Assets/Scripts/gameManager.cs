using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    //gameobjects
    public GameObject player;
    public GameObject mCam;
    //cam stuff
    public float vertAdjustment;
    //score stuff
    public Text scoreText;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
