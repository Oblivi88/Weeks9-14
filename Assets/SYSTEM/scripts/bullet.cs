using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 8; // speed at which bullet flies

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        transform.position += transform.up * speed * Time.deltaTime;

        // object rotates with its parent, moves up when shot
       
    }
}
