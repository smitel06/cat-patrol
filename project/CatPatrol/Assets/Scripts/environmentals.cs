using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class environmentals : MonoBehaviour
{
    //hidden cat stuff
    public GameObject cat;
    public bool isCat; //is there a cat hidden behind
    public GameObject newParent;

    //a behaviour for shaking the object this is attached too
    Transform objectTransform;
    public float shakeDuration = 0f;
    public float shakeMagnitude = 0.0004f;
    float dampingSpeed = 1.0f;
    Vector3 initialPosition;
    //gamemanager so we can call the script
   
    //cursor stuff
    public Texture2D cursorTexture;
    public Texture2D defaultTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;
    //message stuff
    public GameObject screenMessage;
    //sound things
    AudioSource audioPlayer;
    public AudioClip soundEffect;


    // Start is called before the first frame update
    private void Awake()
    {
        if (objectTransform == null)
        {
            objectTransform = gameObject.transform;
        }

        screenMessage = GameObject.Find("catMessage");
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.clip = soundEffect;
    }

    // Update is called once per frame
    void OnEnable()
    {
        initialPosition = objectTransform.localPosition;
    }

    private void Update()
    {
        if (shakeDuration > 0)
        {
            
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    private void OnMouseOver()
    {


        //set cursor for mouse
        Cursor.SetCursor(cursorTexture, hotspot, cursorMode);

        if (Input.GetMouseButtonDown(0))
        {
            clicked();
        }

    }

    void OnMouseExit()
    {
        Cursor.SetCursor(defaultTexture, hotspot, cursorMode);
    }

    public void clicked()
    {
        audioPlayer.Play();
        shakeDuration = 0.5f;
        Cursor.SetCursor(defaultTexture, hotspot, cursorMode);
        //if there is a cat enable him and do behaviour else send message
        if(isCat)
        {
            screenMessage.SendMessage("ShowText", "Something popped out!");
            cat.SetActive(true);
            //detach parent and attach to cats
            cat.transform.parent = null;
            cat.transform.parent = newParent.transform;
            isCat = false;
        }
        else
        {
            screenMessage.SendMessage("ShowText", "There was nothing in there...");
        }
    }

}
