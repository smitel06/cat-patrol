using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCat : MonoBehaviour
{
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
        
    }

    public void spawnRandom()
    {
        //set random sprite
        randomNum = Random.Range(0, 26);
        randomFloat = Random.Range(0.25f, 0.51f);
        //if certain cats do not change the scale
        if(randomNum == 11 || randomNum == 12 || randomNum == 13 || randomNum == 14 || randomNum == 15 || randomNum == 16 || randomNum == 17 || randomNum == 18 || randomNum == 19 || randomNum == 20)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
            transform.localScale = new Vector3(randomFloat, randomFloat, 1);
        
        m_renderer.sprite = sprites[randomNum];
        //random gravity scale
        m_body.gravityScale = Random.Range(0.2f, 1.5f);

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
