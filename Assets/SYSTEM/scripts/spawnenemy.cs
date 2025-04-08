using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnenemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Spawn()
    {
        GameObject spawnedEnemy = Instantiate(enemy);
        spawnedEnemy.GetComponent<Enemies>().player = player;
    }

}
