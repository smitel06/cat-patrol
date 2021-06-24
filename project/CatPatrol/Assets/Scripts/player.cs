using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //this script will be for keyboard and mouse control


    public GameObject gameManager;
    //is the player facing left
    bool facingLeft = false;
    //buildings/path
    public GameObject rotationObjects;
    public float rotationSpeed;
    //animations
    Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        // get animator attached to this object
        m_Animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

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
            //add very small rotation to building
            rotationObjects.transform.Rotate(0f, rotationSpeed, 0f, Space.World);

            //animate walking animation trigger
            m_Animator.SetTrigger("walk");
            //turn off not walking
            m_Animator.ResetTrigger("not_walking");

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
            //add very small rotation to buildings and path
            rotationObjects.transform.Rotate(0f, -rotationSpeed, 0f, Space.World);

            //animate walking animation trigger
            m_Animator.SetTrigger("walk");
            //turn off not walking
            m_Animator.ResetTrigger("not_walking");

        }
        else
        {
            //reset all animation triggers when not moving
            m_Animator.ResetTrigger("walk");
            //set idle animation
            m_Animator.SetTrigger("not_walking");


        }

    }


    void Update()
    {
        
    }
}










   

