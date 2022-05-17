using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private RespawnManager rm;
    public HappinessBar happinessBar;
    private FallDamage fallDamage;
    public float deathTimer;
    public bool dying;

    void Start()
    {
        fallDamage = GetComponent<FallDamage>();
        rm = GameObject.FindGameObjectWithTag("RM").GetComponent<RespawnManager>();
        transform.position = rm.lastCheckPointPos;
    }
    void Update()
    {
        if (gameObject.transform.position.y < -25 && dying == false)
        {
            deathTimer = 0f;
            Debug.Log("Out of bounds");
            RespawnPlayer();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //resets player position on death
        if (GetComponent<Happiness>().currentHealth <= 0 && dying == false)
        {
            if (GetComponent<PlayerSwing>().attached == true)
            {
                GetComponent<PlayerSwing>().Detatch();
            }
            Debug.Log("No Happiness left");
            deathTimer = 3f;
            RespawnPlayer();
        }

        if (Input.GetKeyDown("1"))
        {
            transform.position = GameObject.Find("Checkpoint 1").GetComponent<Transform>().position;
        }
        if (Input.GetKeyDown("2"))
        {
            transform.position = GameObject.Find("Checkpoint 2").GetComponent<Transform>().position;
        }
        if (Input.GetKeyDown("3"))
        {
            transform.position = GameObject.Find("Checkpoint 3").GetComponent<Transform>().position;
        }
        if (Input.GetKeyDown("4"))
        {
            transform.position = GameObject.Find("Checkpoint 4").GetComponent<Transform>().position;
        }
        if (Input.GetKeyDown("5"))
        {
            transform.position = GameObject.Find("Checkpoint 5").GetComponent<Transform>().position;
        }
    }

    void RespawnPlayer()
    {

        if (GetComponent<Movement>().isGrounded == true)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        dying = true;
        GetComponent<Movement>().canMove = false;
        StartCoroutine(death());
    }
    IEnumerator death()
    {
        GetComponent<RealAnimationController>().stop();
        GetComponent<RealAnimationController>().enabled = false;
        GetComponent<RealAnimationController>().enabled = true;
        yield return new WaitForSeconds(deathTimer);
        dying = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<Happiness>().currentHealth = GetComponent<Happiness>().maxHealth;
        happinessBar.SetHealth(GetComponent<Happiness>().currentHealth);
        transform.position = rm.lastCheckPointPos;
        fallDamage.airTime = 0;

        GetComponent<Movement>().canMove = true;
    }
}
