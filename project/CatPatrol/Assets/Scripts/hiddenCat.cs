using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiddenCat : MonoBehaviour
{
    
    SpriteRenderer spriteRen;
    Rigidbody2D rBody;
    public float force;
    public float timeToWait;
    public float waitTime;
    

    private void OnEnable()
    {
        spriteRen = GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        //add some force 
        rBody.velocity = new Vector2(rBody.velocity.x, force);
        
        spriteRen.sortingOrder = 0;
        timeToWait = waitTime + Time.time;
    }

    private void FixedUpdate()
    {
        if(Time.time > timeToWait)
        {
            Destroy(rBody);
        }
    }





}
