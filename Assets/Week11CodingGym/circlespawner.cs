using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class circlespawner : MonoBehaviour
{

    public GameObject circle;
    public int t = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(circle);
    }

    // Update is called once per frame
    void Update()
    {
        t++;

        if (t % 960 == 0)
        {
            Instantiate(circle);
        }
    }
}
