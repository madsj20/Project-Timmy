using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    GameObject timmy;
    Movement timmyMove;
    Happiness timmyHappi;
    CameraShake cameraShake;

    public bool falling;

    float minSurviveFall = 1.1f;
    float damageForSeconds = 50f;
    public float airTime = 0;
    bool hitBouncy = false;
    bool damageFall = false;

    GameObject audios;

    // Start is called before the first frame update
    private void Awake()
    {
        audios = GameObject.Find("AudioManager");
    }

    void Start()
    {
        damageFall = false;
        falling = true;
        cameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        timmy = GameObject.Find("Timmy");
        timmyMove = timmy.GetComponent<Movement>();
        timmyHappi = timmy.GetComponent<Happiness>();
        airTime = -4;


    }

    // Update is called once per frame
    void Update()
    {
        

        if(airTime > minSurviveFall && falling == true)
        {
            audios.GetComponent<AudioController>().falldamageON();
        }

        if(falling == false && airTime < minSurviveFall)
        {
            audios.GetComponent<AudioController>().falldamageOFF();
        }
      

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
                    damageFall = true;
                    timmyHappi.TakeDamage(((int)(damageForSeconds * airTime)),0);
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
