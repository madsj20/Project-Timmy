using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrower : MonoBehaviour
{
    public Rigidbody2D rock;
    private GameObject Timmy;
    private GameObject hitSquare;
    private float launchForce = 50f;

    private void Start()
    {
        Timmy = GameObject.Find("Timmy");
        hitSquare = GameObject.Find("HitSquare");
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && Timmy.GetComponent<HitEnemy>().hasHit == false)
        {
            Debug.Log("Rock Throw");
            Rigidbody2D rockInstance = Instantiate(rock, transform.position, Quaternion.Euler(0, 30/*Timmy.GetComponent<HitEnemy>().angle*/, 0)) as Rigidbody2D;
            rockInstance.velocity = launchForce * transform.up;
        }
    }

}
