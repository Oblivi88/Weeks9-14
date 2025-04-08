using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject player;
    public float speed = 0.75f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 direction = playerPosition - (Vector2)transform.position;
        transform.up = direction;
        transform.position += transform.up * speed * Time.deltaTime;




    }
}
