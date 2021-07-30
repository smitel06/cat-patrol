using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCat : MonoBehaviour
{
    //cursor stuff
    public Texture2D cursorTexture;
    public Texture2D defaultTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;
    //other objects
    public GameObject gameManager;
    public GameObject catFrenzy;
    public GameObject screenMessage;

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public Sprite sprite9;
    public Sprite sprite10;
    public Sprite sprite11;
    public Sprite sprite12;
    public Sprite sprite13;
    public Sprite sprite14;
    public Sprite sprite15;
    public Sprite sprite16;
    public Sprite sprite17;
    public Sprite sprite18;
    public Sprite sprite19;
    public Sprite sprite20;
    public Sprite sprite21;
    public Sprite sprite22;
    public Sprite sprite23;
    public Sprite sprite24;
    public Sprite sprite25;
    public Sprite sprite26;
    //list to hold them all
    public List<Sprite> sprites = new List<Sprite>();
    //numbers n such
    int randomNum;
    float randomFloat; //for scaling bigger cats
    //sprite renderer
    SpriteRenderer m_renderer;
    Rigidbody2D m_body;


    // Start is called before the first frame update
    void OnEnable()
    {
        //find gameObjects
        gameManager = GameObject.Find("GameManager");
        catFrenzy = GameObject.Find("cat frenzy");
        screenMessage = GameObject.Find("catMessage");

        m_renderer = gameObject.GetComponent<SpriteRenderer>();
        m_body = gameObject.GetComponent<Rigidbody2D>();

        //add sprites to list
        sprites.Add(sprite1);
        sprites.Add(sprite2);
        sprites.Add(sprite3);
        sprites.Add(sprite4);
        sprites.Add(sprite5);
        sprites.Add(sprite6);
        sprites.Add(sprite7);
        sprites.Add(sprite8);
        sprites.Add(sprite9);
        sprites.Add(sprite10);
        sprites.Add(sprite11);
        sprites.Add(sprite12);
        sprites.Add(sprite13);
        sprites.Add(sprite14);
        sprites.Add(sprite15);
        sprites.Add(sprite16);
        sprites.Add(sprite17);
        sprites.Add(sprite18);
        sprites.Add(sprite19);
        sprites.Add(sprite20);
        sprites.Add(sprite21);
        sprites.Add(sprite22);
        sprites.Add(sprite23);
        sprites.Add(sprite24);
        sprites.Add(sprite25);
        sprites.Add(sprite26);
        //spawn random
        spawnRandom();

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y == -1)
        {
            Destroy(gameObject);
        }
    }

    public void spawnRandom()
    {
        //set random sprite
        randomNum = Random.Range(0, 26);
        randomFloat = Random.Range(0.25f, 0.55f);
        //if certain cats do not change the scale
        if(randomNum == 11 || randomNum == 12 || randomNum == 13 || randomNum == 14 || randomNum == 15 || randomNum == 16 || randomNum == 17 || randomNum == 18 || randomNum == 19 || randomNum == 20)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
            transform.localScale = new Vector3(randomFloat, randomFloat, 1);
        
        m_renderer.sprite = sprites[randomNum];
        m_renderer.sortingOrder = 100;
        //random gravity scale
        m_body.gravityScale = Random.Range(0.2f, 2f);

        if (m_renderer.sprite == sprite6)
        {
            //pug always same scale
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
            m_body.gravityScale = 0.5f;
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
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

    public void clicked()
    {
        if (m_renderer.sprite == sprite6)
        {
            Cursor.SetCursor(defaultTexture, hotspot, cursorMode);
            //you hit the pug gameover
            catFrenzy.GetComponent<FrenzyBuff>().buffOn = false;
            catFrenzy.GetComponent<FrenzyBuff>().currentValue = 0;
            screenMessage.SendMessage("ShowText", "Detective Frank Stopped The Party!");
            catFrenzy.SendMessage("DestroyRandoms");

        }
        else
        {
            catFrenzy.SendMessage("addValue", 5);
            gameManager.SendMessage("AddToScore");
        }
        Cursor.SetCursor(defaultTexture, hotspot, cursorMode);
        Destroy(gameObject);

    }

    void OnMouseExit()
    {
        Cursor.SetCursor(defaultTexture, hotspot, cursorMode);
    }
}
