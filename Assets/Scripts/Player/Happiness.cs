using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Happiness : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HappinessBar happinessBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        happinessBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("0"))
        {
            currentHealth += 20;
            happinessBar.SetHealth(currentHealth);
        }

        if (Input.GetKeyDown("9"))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        happinessBar.SetHealth(currentHealth);
    }
}
