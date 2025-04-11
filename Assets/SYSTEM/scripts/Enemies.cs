using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Enemies : MonoBehaviour
{
    public GameObject player; // reference to player
    public float speed = 0.75f; 
    public int HP = 3; // health per each enemy spawned
    public GameObject spawner; // reference to the spawner
    public GameObject bulletSpawner; // reference to the bulletspawner, making sure enemies dont take damage when out of ammo
    

    SpriteRenderer sr;
    spawnenemy spawnerscript;

    bulletspawner bulletSpawnerScript;

    public Color orange; // middle damage stage colour

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        spawnerscript = spawner.GetComponent<spawnenemy>();
        bulletSpawnerScript = bulletSpawner.GetComponent<bulletspawner>(); // getting the necessary script componenets and spriterenderer components
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // mouse position tracking
        Vector2 playerPosition = player.transform.position; // tracking playerposition using the reference to the player
        Vector2 direction = playerPosition - (Vector2)transform.position;
        transform.up = direction;
        transform.position += transform.up * speed * Time.deltaTime; // always point towards player and slowly move towards them

        if (Input.GetMouseButtonDown(0) && bulletSpawnerScript.ammo > 0) // if mouse is clicked and gun has ammo in it,
        {
            if (sr.bounds.Contains(mousePos)) // if the mouse is within this enemy
            {
                if (spawnerscript.oneShotKills == false) // if one shot kills is off do normal damage
                {
                    HP--;
                }
                if (spawnerscript.oneShotKills == true)
                {
                    HP -= 3;
                }
                
                if (HP == 2) // changes colour based off damage stages
                {
                    sr.color = orange;
                }
                if (HP == 1)
                {
                    sr.color = Color.red;
                }
                if (HP <= 0) // when enemy is killed, increase the kill count, start/reset the killstreak timer, increase/start the amount of kills during the timer
                {
                    spawnerscript.increaseKillCount();
                    spawnerscript.StartCoroutine(spawnerscript.KillStreakTimer());
                    spawnerscript.killsDuringTimer++;
                    Destroy(gameObject);
                    
                }
            } 
        }

        



    }

    public void destroyObject() // called when play again button is clicked
    {
            Destroy(gameObject);
        
    }
    


}
