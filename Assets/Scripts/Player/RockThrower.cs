using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrower : MonoBehaviour
{
    public Rigidbody2D rock;
    private GameObject Timmy;
    private GameObject hitSquare;
    private float launchForce = 30f;

    private void Start()
    {
        Timmy = GameObject.Find("Timmy");
        hitSquare = GameObject.Find("HitSquare");
    }

    public void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space) && Timmy.GetComponent<HitEnemy>().hasHit == true)
        {
            Debug.Log("Rock Throw");
            Rigidbody2D rockInstance = Instantiate(rock, transform.position, transform.rotation) as Rigidbody2D;
            rockInstance.velocity = launchForce * transform.up;
        }*/
    }

}
