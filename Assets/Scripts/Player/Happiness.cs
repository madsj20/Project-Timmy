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
    public bool checker;
    public int knockbackForceUp;
    public int knockbackForceSides;


    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        happinessBar.SetMaxHealth(maxHealth);

        rb = this.gameObject.GetComponent<Rigidbody2D>();
        knockbackForceUp = 15;
        knockbackForceSides = 10;
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

        if (isKnocked && GetComponent<Movement>().isGrounded == true && checker)
        {
            StopCoroutine(CanMoveAgain());
            GetComponent<Movement>().canMove = true;
        }
    }
    private void FixedUpdate()
    {
        //rb.AddForce(Vector2.left * 20f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Bird") && !isKnocked)
        {
            enemyTf = other.transform;
            TakeDamage(10);
            knockback();
            Debug.Log("Hit by: " + other);
        }
        if (other.gameObject.CompareTag("Squirrel") && !isKnocked)
        {
            enemyTf = other.transform;
            TakeDamage(10);
            knockback();
            Debug.Log("Hit by: " + other);
        }
        if (other.gameObject.CompareTag("Spikes") && !isKnocked)
        {
            enemyTf = other.transform;
            TakeDamage(15);
            knockback();
            Debug.Log("Hit by: " + other);
        }
        if (other.gameObject.CompareTag("BirdShit") && !isKnocked)
        {
            enemyTf = other.transform;
            TakeDamage(15);
            Destroy(other.gameObject);
            knockback();
            Debug.Log("Hit by: " + other);
        }
    }
    private void OnTriggerEnter2D (Collider2D other)
    {

        if (other.gameObject.CompareTag("Bird") && !isKnocked)
        {
            enemyTf = other.transform;
            TakeDamage(10);
            
            Debug.Log("Hit by: " + other);
        }
        if (other.gameObject.CompareTag("Squirrel") && !isKnocked)
        {
            
            TakeDamage(10);
            
            Debug.Log("Hit by: " + other);
        }
        if (other.gameObject.CompareTag("Spikes") && !isKnocked)
        {
            
            TakeDamage(15);
            
            Debug.Log("Hit by: " + other);
        }
        if (other.gameObject.CompareTag("BirdShit") && !isKnocked)
        {
            
            TakeDamage(15);
            Destroy(other.gameObject);
           
            Debug.Log("Hit by: " + other);
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
        rb.AddForce(Vector2.up * knockbackForceUp, ForceMode2D.Impulse);
        if (transform.position.x < enemyTf.position.x)
        {
            rb.AddForce(Vector2.left * knockbackForceSides, ForceMode2D.Impulse);
        }
        else
        {
            
            rb.AddForce(Vector2.right * knockbackForceSides, ForceMode2D.Impulse);
        }
        
    }

    void check()
    {
        if (isKnocked && GetComponent<Movement>().isGrounded == true)
        {
            StopCoroutine(CanMoveAgain());
            GetComponent<Movement>().canMove = true;
        }
    }
    IEnumerator CanMoveAgain()
    {
        isKnocked = true;
        GetComponent<Movement>().canMove = false;
        yield return new WaitForSeconds(0.3f);
        checker = true;

        yield return new WaitForSeconds(1f);
        GetComponent<Movement>().canMove = true;
        isKnocked = false;
        checker = false;
    }
}
