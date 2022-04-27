using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    GameObject timmy;
    Movement timmyMove;
    Happiness timmyHappi;
    CameraShake cameraShake;

    float minSurviveFall = 0.7f;
    float damageForSeconds = 30f;
    public float airTime = 0;
    bool climb = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        timmy = GameObject.Find("Timmy");
        timmyMove = timmy.GetComponent<Movement>();
        timmyHappi = timmy.GetComponent<Happiness>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!timmyMove.isGrounded && !timmyMove.climb)
        {
            airTime += Time.deltaTime;
        }
        if(timmyMove.isGrounded)
        {
            if(airTime > minSurviveFall)
            {
                timmyHappi.TakeDamage(((int)(damageForSeconds * airTime)));
                Debug.Log((int)(damageForSeconds * airTime));
                StartCoroutine(cameraShake.Shake(0.1f, 0.4f));
            }
            airTime = 0;
        }
    }
}
