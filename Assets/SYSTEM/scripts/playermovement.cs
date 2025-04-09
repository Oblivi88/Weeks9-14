using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    public Sprite walkingLeft;
    public Sprite walkingRight;
    public Sprite walkingUp;
    public Sprite walkingDown;

    SpriteRenderer sr;

    Vector2 pos = new Vector2(0, -3.5f);

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    }
        
