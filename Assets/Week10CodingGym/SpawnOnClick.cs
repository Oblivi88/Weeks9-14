using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnClick : MonoBehaviour
{

    public GameObject farm;
    Vector2 spawnPos = new Vector3(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = spawnPos;
            Instantiate(farm, spawnPos, farm.transform.rotation);
        }
    }
}
