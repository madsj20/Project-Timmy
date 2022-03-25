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
            GiveHappiness(20);
        }

        if (Input.GetKeyDown("9"))
        {
            TakeDamage(20);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bird")
        {
            TakeDamage(10);
        }
        if (other.gameObject.tag == "Squirrel")
        {
            TakeDamage(10);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BirdShit")
        {
            TakeDamage(15);
            Destroy(other.gameObject);
        }
    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        happinessBar.SetHealth(currentHealth);
    }

    void GiveHappiness(int happiness)
    {
        currentHealth += happiness;
        happinessBar.SetHealth(currentHealth);
    }
}
