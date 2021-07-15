using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catParentObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        //broadcast pause to cats
        gameObject.BroadcastMessage("Paused");
        gameObject.BroadcastMessage("Unclickable");
    }

    public void Unpause()
    {
        //broadcast unpause to all cats
        gameObject.BroadcastMessage("Unpaused");
        gameObject.BroadcastMessage("Clickable");

    }
}
