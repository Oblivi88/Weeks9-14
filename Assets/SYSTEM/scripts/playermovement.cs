using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playermovement : MonoBehaviour
{

    public Sprite walkingLeft; // references to the four directional sprites
    public Sprite walkingRight;
    public Sprite walkingUp;
    public Sprite walkingDown;

    public GameObject enemy; // reference to the enemies

    SpriteRenderer sr;

    Vector2 pos = new Vector2(0, -3.5f); // default starting position

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); // get spriterenderer component
    }

    // Update is called once per frame
    void Update()
    {
        // movement code - when a key is pressed, show that sprite and change x or y value
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.A))
        {
            sr.sprite = walkingLeft;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            sr.sprite = walkingUp;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            sr.sprite = walkingDown;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            sr.sprite = walkingRight;
        }

        if (Input.GetKey(KeyCode.A))
        {
            pos.x -= 0.01f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            pos.y += 0.01f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= 0.01f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x += 0.01f;
        }
        // out of bounds code - if a player approaches the walls, push back
        if (pos.x >= 6.36f)
        {
            pos.x = 6.35f;
        }
        if (pos.x <= -6.36f)
        {
            pos.x = -6.35f;
        }
        if (pos.y <= -4.47f)
        {
            pos.y = -4.46f;
        }

        if (pos.y >= 4.42f)
        {
            pos.y = 4.41f;
        }
    }

    public void ResetPos() // called when play again button is clicked, will reset player back to default starting pos
    {
        pos.x = 0;
        pos.y = -3.5f;
    }
}
        
