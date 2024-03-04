using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float maxHealth = 10f;
    public float health = 10f;

    [SerializeField] private GameObject healthBar;

    public void takeDamage (float damage)
    {
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
