using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagle : MonoBehaviour
{
    public GameObject followers;
    public float speed;
    public GameObject rotator;
    public bool increaseSpeed;
    //list of followers
    public List<GameObject> followersList = new List<GameObject>();
    //player
    public GameObject player;
    //distance
    public float distance;
    public GameObject cat;
    bool steal;
    public float maxDistance;
    public float distanceFromPrey;
    bool stolen;
    public GameObject prey;
    public GameObject positioner;
    public float waitTime;
    public float timeToWait;
    bool pickedUp;
    bool setTimer;
    bool carrying;

    void Start()
    {
        timeToWait = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTime < Time.time && pickedUp)
        {
            transform.position = positioner.transform.position;
            transform.rotation = positioner.transform.rotation;
            stolen = false;
            setTimer = false;
            carrying = true;
            pickedUp = false;
        }

        if(carrying)
        {

            rotator.transform.Rotate(0f, 0.10f, 0f, Space.World);
            //all click logic can go in here 
        }

        //public float distance
        distance = Vector2.Distance(gameObject.transform.position, player.transform.position);

        if (distance < 10 && !steal && !stolen)
            steal = true;
        //steal
        if (steal)
        {
            stealCat();
            distanceFromPrey = Vector2.Distance(cat.transform.position, transform.position);
        }

        if(distanceFromPrey < 1 && steal)
        {
            prey.GetComponent<SpriteRenderer>().sprite = cat.GetComponent<SpriteRenderer>().sprite;
            cat.SetActive(false);
            prey.SetActive(true);
            stolen = true;
            steal = false;

        }

        if(stolen)
        {
            //rotator.transform.Rotate(0f, 0.10f, 0f, Space.World);
            transform.position = Vector2.MoveTowards(gameObject.transform.position, positioner.transform.position, maxDistance * Time.deltaTime);
            if (!setTimer)
            {
                waitTime = timeToWait + Time.time;
                setTimer = true;
            }

            pickedUp = true;

        }



        if (!steal && !stolen && !pickedUp)
        {
            //movement things
            if (increaseSpeed)
                rotator.transform.Rotate(0f, 1f, 0f, Space.World);
            else
                rotator.transform.Rotate(0f, speed, 0f, Space.World);
        }
        //make sure you don't have all followers
        if(followersList.Count < followers.transform.childCount)
            pickCat();
    }

    void pickCat()
    {
        followersList.Clear();
        //get all followers in the list
        foreach(Transform child in followers.transform)
        {
            followersList.Add(child.gameObject);
        }

        cat = followersList[Random.Range(0, followersList.Count - 1)];


    }

    void stealCat()
    {
        GetComponent<SpriteRenderer>().sortingOrder = cat.GetComponent<SpriteRenderer>().sortingOrder + 1;
        transform.position = Vector2.MoveTowards(gameObject.transform.position, cat.transform.position, maxDistance * Time.deltaTime);
    }

    


}
