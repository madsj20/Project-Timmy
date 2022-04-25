using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private RespawnManager rm;

    void Start()
    {
        rm = GameObject.FindGameObjectWithTag("RM").GetComponent<RespawnManager>();
        transform.position = rm.lastCheckPointPos;
    }
    void Update()
    {
        if (gameObject.transform.position.y < rm.lastCheckPointPos.y - 25)
        {
            Debug.Log("Out of bounds");
            transform.position = rm.lastCheckPointPos;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (GetComponent<Happiness>().currentHealth <= 0)
        {
            Debug.Log("No Happiness left");
            transform.position = rm.lastCheckPointPos;
            GetComponent<Movement>().canMove = false;
        }
    }
}
