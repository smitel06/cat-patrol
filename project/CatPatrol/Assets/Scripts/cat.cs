using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cat : MonoBehaviour
{
    public GameObject gameManager;
    public string clickMessage;
    public GameObject screenMessage;
    //buff
    public GameObject catFrenzy;
    
    //movement
    public GameObject rotator; //used for pivot to move cat on path
    public float movementSpeed;
    Animator m_Animator;
    //wait to change movement 
    public float movementWait;
    float changeMovementTime;
    bool moveLeft;
    bool moveRight;
    bool idle;
    bool facingLeft;
    bool changeMovement;
    //rand
    int randomNum;
    //cursor stuff
    public Texture2D cursorTexture;
    public Texture2D defaultTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;
    //bool for movement
    public bool canMove;
    //bool for pause stuff
    bool allowedToMoveAgain;
    bool canClick;
    //follower stuff
    public GameObject catFollower; //assign corresponding follower 
    //random start stuff
    public float randomRot;


    // Start is called before the first frame update
    void Start()
    {


        // get animator attached to this object
        m_Animator = gameObject.GetComponent<Animator>();
        //set time to wait in between deciding between movement options
        

        //starting spot
        randomRot = Random.Range(1, 361);
        rotator.transform.Rotate(0f, randomRot, 0f, Space.World);




        //saet movement bools
        idle = true;
        moveRight = false;
        moveLeft = false;
        facingLeft = true;
        changeMovement = true;
        randomNum = 1;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (canMove)
        {

            if (Time.time > changeMovementTime)
            {
                changeMovement = true;
            }
            //movement
            if (changeMovement)
            {
                //picks between 3 random numbers
                randomNum = Random.Range(1, 4);
                if (randomNum == 1)
                {
                    idle = true;
                    moveLeft = false;
                    moveRight = false;
                }
                else if (randomNum == 2)
                {
                    moveLeft = true;
                    idle = false;
                    moveRight = false;
                }
                else if (randomNum == 3)
                {
                    moveRight = true;
                    idle = false;
                    moveLeft = false;
                }

                //wait x seconds to do this again
                changeMovementTime = movementWait + Time.time;
                changeMovement = false;

            }
            if (moveLeft)
            {
                if (!facingLeft)//turns sprite to the left
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                    facingLeft = true;
                }
                //move cat along path
                rotator.transform.Rotate(0f, movementSpeed, 0f, Space.World);
                m_Animator.SetBool("walking", true);
            }
            if (moveRight)
            {
                if (facingLeft)//turns sprite to the right
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                    facingLeft = false;
                    m_Animator.SetBool("walking", true);

                }
                //move cat along path
                rotator.transform.Rotate(0f, -movementSpeed, 0f, Space.World);
                m_Animator.SetBool("walking", true);
            }
            if (idle)
            {
                m_Animator.SetBool("walking", false);
            }
        }
        else
        {
            m_Animator.SetBool("walking", false);
        }

    }

    public void clicked()
    {
        if (canClick)
        {
            //add cat follower to active
            catFollower.SetActive(true);

            catFrenzy.SendMessage("addValue");
            gameManager.SendMessage("AddToScore");
            screenMessage.SendMessage("ShowText", clickMessage);
            Cursor.SetCursor(defaultTexture, hotspot, cursorMode);
            Destroy(gameObject);
        }

    }

    private void OnMouseOver()
    {
        if (canClick)
        {
            //set cursor for mouse
            Cursor.SetCursor(cursorTexture, hotspot, cursorMode);

            if (Input.GetMouseButtonDown(0))
            {
                clicked();
            }
        }
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(defaultTexture, hotspot, cursorMode);
    }

    public void Paused()
    {
        if (canMove == true)
        {
            allowedToMoveAgain = true;
            canMove = false;
        }
    }

    public void Unpaused()
    {
        if (allowedToMoveAgain)
        {
            canMove = true;
            allowedToMoveAgain = false;
        }
    }

    public void Unclickable()
    {
        canClick = false;
        
    }

    public void Clickable()
    {
        canClick = true;
    }


}
