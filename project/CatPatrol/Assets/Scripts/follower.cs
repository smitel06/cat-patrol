using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follower : MonoBehaviour
{
    public GameObject gameManager;
    //is the player facing left
    bool facingLeft = false;
    //animations
    Animator m_Animator;
    //parents
    public GameObject rotationParent;
    public GameObject player;
    bool detached;
    //distance between cat and player
    public float distance;
    public float distanceTillChange;
    
    


    // Start is called before the first frame update
    void Start()
    {
        // get animator attached to this object
        m_Animator = gameObject.GetComponent<Animator>();
        //set distance to wait to for changing attachment
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector2.Distance(player.transform.position, this.gameObject.transform.position);
        if(detached)
        {
           
            if(distance >= distanceTillChange)
            {
                //attach back to player
                SetParent(player);
                detached = false;
                
            }
        }
        //get distance between
        {
            distance = Vector2.Distance(this.gameObject.transform.position, player.transform.position);
        }
        //controls for movement 
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))//move right
        {
            
            if (facingLeft)//turns sprite to the right
            {
                
                //flip the sprite
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                facingLeft = false;

                //change parent to stop follow of player
                SetParent(rotationParent);
                detached = true;
            }

            if(!detached)
                m_Animator.SetBool("walking", true);

            
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))//move left
        {
            if (facingLeft == false)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                facingLeft = true;

                //change parent to stop follow of player
                SetParent(rotationParent);
                detached = true;
            }

            if(!detached)
                m_Animator.SetBool("walking", true);
            
            //if not locked to player
            

        }
        else
        {
            m_Animator.SetBool("walking", false);
        }

    }

    //parent attaching things
    public void SetParent(GameObject newParent)
    {
        //Makes the GameObject "newParent" the parent of the GameObject cat.
        this.gameObject.transform.parent = newParent.transform;

    }

    public void DetachFromParent()
    {
        // Detaches the transform from its parent.
        transform.parent = null;
    }


}
