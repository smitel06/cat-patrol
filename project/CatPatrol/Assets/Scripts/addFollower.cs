using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addFollower : MonoBehaviour
{
    //this script adds followers to the player once corresponding cat has been found

    public GameObject gameManager;
    GameObject[] followers;
    //used to store temporary objects
    GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        //add all children to list
        followers = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            followers[i] = transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //get the score to use as index for tally
        for (int i = 0; i < gameManager.GetComponent<gameManager>().score; i++)
        {
            temp = followers[i];
            //add score
            if (temp.activeSelf == false)
                temp.SetActive(true);
        }
    }
}
