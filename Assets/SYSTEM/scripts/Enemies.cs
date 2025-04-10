using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemies : MonoBehaviour
{
    public GameObject player;
    public float speed = 0.75f;
    public int HP = 3;

    public UnityEvent EnemyDies;

    SpriteRenderer sr;


    public Color orange;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPosition = player.transform.position;
        Vector2 direction = playerPosition - (Vector2)transform.position;
        transform.up = direction;
        transform.position += transform.up * speed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (sr.bounds.Contains(mousePos))
            {
                HP--;
                if (HP == 2)
                {
                    sr.color = orange;
                }
                if (HP == 1)
                {
                    sr.color = Color.red;
                }
                if (HP == 0)
                {
                    Destroy(gameObject);
                    EnemyDies.Invoke();
                }
            } 
        }

        



    }

    
}
