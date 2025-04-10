using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnenemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    GameObject spawnedEnemy;

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
        Vector2 RandomSpawn = new Vector2(transform.position.x + Random.Range(-6, 6), transform.position.y + Random.Range(-3, 2));

        spawnedEnemy = Instantiate(enemy, RandomSpawn, transform.rotation);
        spawnedEnemy.GetComponent<Enemies>().player = player;
    }

    

}
