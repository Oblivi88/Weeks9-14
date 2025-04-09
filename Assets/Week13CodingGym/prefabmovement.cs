using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabmovement : MonoBehaviour
{

    public float speed = 1;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = Random.ColorHSV();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - (Vector2)transform.position;
        transform.up = direction;
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
