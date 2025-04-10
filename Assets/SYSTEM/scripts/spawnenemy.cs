using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class spawnenemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    GameObject spawnedEnemy;

    public UnityEvent PlayerDies;

    public float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedEnemy != null)
        {
            if (player.transform.position.x >= spawnedEnemy.transform.position.x - 0.7f && player.transform.position.x <= spawnedEnemy.transform.position.x + 0.7f && player.transform.position.y >= spawnedEnemy.transform.position.y - 0.7f && player.transform.position.y <= spawnedEnemy.transform.position.y + 0.7f)
            {
                PlayerDies.Invoke();
            }
        }

        t++;
        if (t % 800 == 0)
        {
            Vector2 RandomSpawn = new Vector2(transform.position.x + Random.Range(-6, 6), transform.position.y + Random.Range(-3, 2));

            spawnedEnemy = Instantiate(enemy, RandomSpawn, transform.rotation);
            spawnedEnemy.GetComponent<Enemies>().player = player;

        }

    }

    public void DestroyAll()
    {
        for (int i =  0; i < 30; i++)
        {
            Destroy(spawnedEnemy);
        }
    }

    

}
