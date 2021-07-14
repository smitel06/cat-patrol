using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catParentObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        //broadcast pause to cats
        gameObject.BroadcastMessage("Paused");
    }

    public void Unpause()
    {
        //broadcast unpause to all cats
        gameObject.BroadcastMessage("Unpaused");


    }
}
