using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private RespawnManager rm;
    public HappinessBar happinessBar;
    private FallDamage fallDamage;

    void Start()
    {
        fallDamage = GetComponent<FallDamage>();
        rm = GameObject.FindGameObjectWithTag("RM").GetComponent<RespawnManager>();
        transform.position = rm.lastCheckPointPos;
    }
    void Update()
    {
        if (gameObject.transform.position.y < -25)
        {
            Debug.Log("Out of bounds");
            RespawnPlayer();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //resets player position on death
        if (GetComponent<Happiness>().currentHealth <= 0)
        {
            Debug.Log("No Happiness left");
            RespawnPlayer();
            GetComponent<Movement>().canMove = true;
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
        GetComponent<Happiness>().currentHealth = GetComponent<Happiness>().maxHealth;
        happinessBar.SetHealth(GetComponent<Happiness>().currentHealth);
        transform.position = rm.lastCheckPointPos;
        fallDamage.airTime = 0;
    }
}
