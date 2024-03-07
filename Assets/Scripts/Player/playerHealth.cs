using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float maxHealth = 10f;
    public float health = 10f;

    private float currentTime = 0;
    private float flashTime = 0;
    public float flashDuration = 0.05f;
    
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject redFlash;

    private void Start()
    {
        redFlash.SetActive(false);
    }

    public void takeDamage (float damage)
    {
        flashTime = currentTime;
        redFlash.SetActive(true);

        health -= damage;

        if (health <= 0 )
        {
            health = 0;
        }

        healthBar.GetComponent<updateHealthbar>().changeHealthbar(health);
    }

    public void takeHealing (float heal)
    {
        health += heal;

        if (health >= maxHealth ) 
        {
            health = maxHealth;
        }

        healthBar.GetComponent<updateHealthbar>().changeHealthbar(health);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime-flashTime > flashDuration)
        {
            redFlash.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.L)) 
        {
            takeDamage(1);
        };

        if (Input.GetKeyDown(KeyCode.K))
        {
            takeHealing(1);
        };
    }
}
