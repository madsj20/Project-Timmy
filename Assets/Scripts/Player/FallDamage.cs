using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    GameObject timmy;
    Movement timmyMove;
    Happiness timmyHappi;
    CameraShake cameraShake;

    float minSurviveFall = 1.1f;
    float damageForSeconds = 30f;
    public float airTime = 0;
    bool hitBouncy = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        timmy = GameObject.Find("Timmy");
        timmyMove = timmy.GetComponent<Movement>();
        timmyHappi = timmy.GetComponent<Happiness>();
        airTime = -4;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitBouncy == false)
        {
            if (!timmyMove.isGrounded && !timmyMove.climb)
            {
                airTime += Time.deltaTime;
            }
            if (timmyMove.isGrounded)
            {
                if (airTime > minSurviveFall)
                {
                    timmyHappi.TakeDamage(((int)(damageForSeconds * airTime)));
                    Debug.Log((int)(damageForSeconds * airTime));
                    StartCoroutine(cameraShake.Shake(0.1f, 0.4f));
                }
                airTime = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "BouncyPlatform")
        {
            Debug.Log("Hit Bouncy Platform");
            hitBouncy = true;
            airTime = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "BouncyPlatform")
        {
            Debug.Log("Left Bouncy Platform");
            hitBouncy = false;
        }
    }
}
