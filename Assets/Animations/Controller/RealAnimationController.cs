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

        if (Input.GetKeyDown("a") || Input.GetKeyDown("d")) // && (this.GetComponent<Movement>().isGrounded = true)) aka se om timmy står på jorden
        {
            anim.SetBool("isRunnings", true);
        }
        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            anim.SetBool("isRunnings", true);
        }
        if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            anim.SetBool("isRunnings", false);
        }

        /*
         if (Input.GetKeyDown("w"))
         {
             //stop();
             anim.SetBool("isJumping", true);
         }
         if (Input.GetKeyDown("a") || Input.GetKeyDown("d"))
         {
             //stop();
             anim.SetBool("isIdeal", false);
             anim.SetBool("isRunnings", true);
         }
         else
         {
             anim.SetBool("isRunnings", false);
         }
        */
    }
    public void stop()
    {
        anim.SetBool("isRunnings", false);
        anim.SetBool("isJumping", false);
        anim.SetBool("isFalling", false);
        anim.SetBool("isIdeal", false);
        //anim.SetBool("isWall", false); //disse animationer er ikke lavet endnu 
        //anim.SetBool("isSwinging", false); //same 
    }


}
