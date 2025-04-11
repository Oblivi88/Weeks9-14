using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class killStreakTimer : MonoBehaviour
{

    Slider slider;
    public GameObject enemySpawner;
    spawnenemy enemySpawnerScript; // reference to the enemy spawner script, to access the killstreak timer
    
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        enemySpawnerScript = enemySpawner.GetComponent<spawnenemy>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = enemySpawnerScript.killStreakChecktimer; // make the timer display the killstreak timer
    }
}
