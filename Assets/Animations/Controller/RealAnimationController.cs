using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealAnimationController : MonoBehaviour
{
    private Animator anim;
    void Awake()
    {
 
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            // jump animaiton
        }
        if (Input.GetKeyDown("a") || Input.GetKeyDown("d"))
        {
            //isRunnings = true;
            anim.SetBool("isRunnings", true);
        }
        else
        {

            //animator.SetBool("isRunnings", false);
        }
    }


}
