using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletspawner : MonoBehaviour
{
    public GameObject Bullet;
    GameObject FiredBullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    public void FireBullet()
    {
        FiredBullet = Instantiate(Bullet, transform.position, transform.rotation);
        Destroy(FiredBullet, 0.8f);
    }
}
