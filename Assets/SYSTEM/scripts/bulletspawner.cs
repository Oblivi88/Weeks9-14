using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class bulletspawner : MonoBehaviour
{

    public GameObject Bullet; // reference to the bullets it will shoot
    GameObject FiredBullet;

    public GameObject enemySpawner;
    spawnenemy enemySpawnerScript; // getting a reference to the enemy spawner and its script, this is to access the infiniteammo boolean

    public int ammo = 10; // how many bullets can be shot before reload
    float cooldownTimer = 5; // how long it takes for the gun to reload

    public TextMeshProUGUI ammoCounter;// will display the ammo on screen

    // Start is called before the first frame update
    void Start()
    {
        enemySpawnerScript = enemySpawner.GetComponent<spawnenemy>(); // the script of enemy spawner
    }

    // Update is called once per frame
    void Update()
    {
        if (ammo != 0 && enemySpawnerScript.infiniteAmmo == false) // displays the ammo left, unless 0, then displays cooling down -- unless infinite ammo killstreak perk is on, then displays INFINITE
        {
            ammoCounter.text = ammo.ToString();
        } 
        else if (ammo == 0 && enemySpawnerScript.infiniteAmmo == false)
        {
            ammoCounter.text = "Cooling Down...";
        }
        else if (enemySpawnerScript.infiniteAmmo == true)
        {
            ammoCounter.text = "INFINITE";
        }
        

        if (Input.GetMouseButtonDown(0) && ammo != 0) // if mouse clicked and ammo is not zero, fire, and make sure the cooldown is reset
        {
            FireBullet();
            cooldownTimer = 5;
        }

        if (ammo == 0) // if out of ammo, start cooldown
        {
            gunCooldown();
        }
    }

    public void FireBullet() // called on mouseclick, instantiate a bullet every click, destroy it shortly after
    {
        FiredBullet = Instantiate(Bullet, transform.position, transform.rotation);
        Destroy(FiredBullet, 0.8f);

        if (enemySpawnerScript.infiniteAmmo == false) // as long as infinite ammo is off, subtract ammo like normal
        {
            ammo--;
        }
    }

    public void gunCooldown() // called when ammo = 0, counts down timer and reloads gun
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0)
        {

            ammo = 10;
        }
    }

    public void resetAmmo() // is called when reset button is clicked
    {
        ammo = 10;
    }
}
