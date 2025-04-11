using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class spawnenemy : MonoBehaviour
{

    // used for majority of the game's functionality, outside of spawning enemies.


    public GameObject enemy; // references to necessary objects
    public GameObject player;
    public GameObject spawner;
    public GameObject bulletSpawner;
    GameObject spawnedEnemy;

    public UnityEvent PlayerDies; // unity events that will be invoked
    public UnityEvent KillStreak;
    public UnityEvent KillStreakOver;

    public Button resetButton; // a reference to the reset button, for destroying enemies

    public float t = 0; // increasing float that will routinely spawn enemies

    Enemies enemyscript; // access to the enemies script

    public TextMeshProUGUI killCounter;
    public int killCount = 0; // a text that displays the players killcount, will reset when reset button is clicked

    public int killsDuringTimer = 0; // keeps track of how many kills are gained during the killstreak timer, to determine whether or not a killstreak is granted
    public float killStreakChecktimer; // the killstreak timer

    public bool infiniteAmmo; // these two will activate during a killstreak
    public bool oneShotKills;

    // Start is called before the first frame update
    void Start()
    {
        if (resetButton != null) // preventing nullpoint errors, the reset button is not always active
        {
            resetButton.onClick.AddListener(Destroy);
        }

        infiniteAmmo = false; // make sure the killstreak benefits arent active on start
        oneShotKills = false;
    }
        

    // Update is called once per frame
    void Update()
    {

        killCounter.text = killCount.ToString(); // convert killcount to string to display

        if (spawnedEnemy != null) // preventing nullpoint error
        {
            if (player.transform.position.x >= spawnedEnemy.transform.position.x - 0.7f && player.transform.position.x <= spawnedEnemy.transform.position.x + 0.7f && player.transform.position.y >= spawnedEnemy.transform.position.y - 0.7f && player.transform.position.y <= spawnedEnemy.transform.position.y + 0.7f)
            {
                StopCoroutine(KillStreakTimer()); // if an enemy touches the player, stop the killstreaktimer coroutine and invoke the players death unity event.
                PlayerDies.Invoke(); // when invoked, player disappears, "game over!" and reset button UI appears, and enemy spawner is disabled
            }
        }

        t++; // routinely spawn enemies
        if (t % 800 == 0)
        {
            Vector2 RandomSpawn = new Vector2(transform.position.x + Random.Range(-6, 6), transform.position.y + Random.Range(-3, 2)); // the range of which enemies will randomly spawn

            spawnedEnemy = Instantiate(enemy, RandomSpawn, transform.rotation); // spawn an enemy at a random position in that range
            spawnedEnemy.GetComponent<Enemies>().player = player; // because the enemies are a prefab, the references could not be made in the inspector, so working around that,
            spawnedEnemy.GetComponent<Enemies>().spawner = spawner; // I assigned them in this script, using the public references here
            spawnedEnemy.GetComponent<Enemies>().bulletSpawner = bulletSpawner;

        }
        if (spawnedEnemy != null) // prevent nullpoint error, enemies are not always present
        {
            enemyscript = spawnedEnemy.GetComponent<Enemies>();
        }
        
    }

    public void Destroy() // called when play again button is clicked, reset the killcount and destroy enemies
    {
        killCount = 0;
        enemyscript.destroyObject();
    }

    public void increaseKillCount() // called when an enemy dies, in the enemy script
    {
        killCount++;
    }

     
    public IEnumerator KillStreakTimer() // a coroutine that handles the killstreak timer and the killstreak itself
    {

        killStreakChecktimer = 10;
        // while the killstreak timer is still going, keep looping this while loop
        while (killStreakChecktimer > 0)
        {
            killStreakChecktimer -= Time.deltaTime;

            if (killsDuringTimer >= 3) // if the player gets 3 kills during this timer, activate the killstreak perks and invoke the killstreak event
            {
                infiniteAmmo = true;
                oneShotKills = true;
                KillStreak.Invoke(); // displays "killstreak active!" text
            }
                
            yield return null;
        }
        if (killStreakChecktimer <= 0) // if the killstreak timer runs out, reset the kills during timer, and reset the timer. Turn off all perks
        {
            killsDuringTimer = 0;
            killStreakChecktimer = 10;
            infiniteAmmo = false;
            oneShotKills = false;
            KillStreakOver.Invoke(); // hides "killstreak active!" text
        }

    }
}
