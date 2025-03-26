using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class heartmonitor : MonoBehaviour
{

    Vector2 pos = new Vector2(-13, 0);
    public AnimationCurve curve;
    public float t;
    public GameObject circle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pos;

        pos.x += 0.02f;

        if (pos.x >= -6 && pos.x <= -1)
        {
            t += 0.005f;
            pos.y = curve.Evaluate(t);
        }
        if (pos.x >= 0 && pos.x <= 1)
        {
            t = 0;
        }
        if (pos.x >= 3 && pos.x <= 8)
        {
            t += 0.005f;
            pos.y = curve.Evaluate(t);
        }

        if (pos.x >= 27)
        {
            Destroy(circle);
        }
        

        
        
    }
}
