using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //this script will be for keyboard and mouse control


    public GameObject gameManager;
    //public variables to control speed
    public float movementSpeed;
    //is the player facing left
    bool facingLeft = false;
    //set max speed
    public float maxSpeed = 10;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //check speed
        if (GetComponent<Rigidbody2D>().velocity.magnitude > maxSpeed)
        {
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * maxSpeed;
        }

        //controls for movement 
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))//move right
        {
            if (facingLeft)//turns sprite to the right
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                facingLeft = false;
            }
            GetComponent<Rigidbody2D>().AddForce(transform.right * movementSpeed);

        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))//move left
        {
            if (facingLeft == false)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                facingLeft = true;
            }
            GetComponent<Rigidbody2D>().AddForce(transform.right * movementSpeed * -1);

        }
        else
        {
            //stop character from moving around
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }


    void Update()
    {
        //click detection
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //get mouse position
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y); //convert vec3 to vec2

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null) //if ray hit do something
            {
                //check for cat
                if(hit.collider.gameObject.tag == "clickable")
                {
                    //activate click message
                    hit.collider.gameObject.SendMessage("DisplayMessage");
                }
            }
        }
    }
}










   

