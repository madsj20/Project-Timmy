using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Happiness : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HappinessBar happinessBar;
    public Transform enemyTf;
    public bool isKnocked;

    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        happinessBar.SetMaxHealth(maxHealth);

        rb = this.gameObject.GetComponent<Rigidbody2D>();
        
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
    private void FixedUpdate()
    {
        //rb.AddForce(Vector2.left * 20f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Bird" && !isKnocked)
        {
            enemyTf = other.transform;
            TakeDamage(10);
            knockback();
        }
        if (other.gameObject.tag == "Squirrel" && !isKnocked)
        {
            enemyTf = other.transform;
            TakeDamage(10);
            knockback();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BirdShit" && !isKnocked)
        {
            enemyTf = other.transform;
            TakeDamage(15);
            Destroy(other.gameObject);
            knockback();
        }

        if (other.gameObject.tag == "Spikes" && !isKnocked)
        {
            enemyTf = other.transform;
            TakeDamage(15);
            knockback();
            //add knockback
        }
    }


     public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        happinessBar.SetHealth(currentHealth);
    }

    void GiveHappiness(int happiness)
    {
        currentHealth += happiness;
        happinessBar.SetHealth(currentHealth);
    }

    void knockback()
    {

        StartCoroutine(CanMoveAgain());
        rb.AddForce(Vector2.up * 15f, ForceMode2D.Impulse);
        if (transform.position.x < enemyTf.position.x)
        {
            rb.AddForce(Vector2.left * 10f, ForceMode2D.Impulse);
        }
        else
        {
            
            rb.AddForce(Vector2.right * 10f, ForceMode2D.Impulse);
        }
        
    }
    IEnumerator CanMoveAgain()
    {
        isKnocked = true;
        GetComponent<Movement>().canMove = false;
        yield return new WaitForSeconds(1f);
        GetComponent<Movement>().canMove = true;
        isKnocked = false;
    }
}
