using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private float speed = 50.0f;
    private GameObject Timmy;
    private bool moveTorwards = true;

    void Start()
    {
        Timmy = GameObject.Find("Timmy");
    }

    void Update()
    {
        /*if (moveTorwards == true)
        {
            float step = speed * Time.deltaTime;

            // move sprite towards the target location
            //transform.position = Vector2.MoveTowards(transform.position, Timmy.GetComponent<Transform>().position, step);

            //moveTorwards = false;
        }*/
    }
}
