using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private RespawnManager rm;

    void Start()
    {
        rm = GameObject.FindGameObjectWithTag("RM").GetComponent<RespawnManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("New Checkpoint");
            Debug.Log(rm.lastCheckPointPos);
            rm.lastCheckPointPos = transform.position;
            Debug.Log(rm.lastCheckPointPos);
        }
    }
}
