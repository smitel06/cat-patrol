using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tally : MonoBehaviour
{
    //this script adds tally marks forf each cat found in the games journal

    public GameObject gameManager;
    GameObject[] markers;
    //used to store temporary objects
    GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        //add all children to list
        markers = new GameObject[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            markers[i] = transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //get the score to use as index for tally
        for (int i = 0; i < gameManager.GetComponent<gameManager>().score; i++)
        {
            temp = markers[i];
            //add score
            if (temp.activeSelf == false)
                temp.SetActive(true);
        }
    }
}
