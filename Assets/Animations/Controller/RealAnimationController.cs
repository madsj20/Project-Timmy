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

        if ((Input.GetKey("a") || (Input.GetKey("d"))) && this.GetComponent<Movement>().isGrounded == true) //aka se om timmy st�r p� jorden
        {
            stop();
            anim.SetBool("isRunnings", true);
            Debug.Log("isGrounded: " + this.GetComponent<Movement>().isGrounded);
            Debug.Log("Animation bool: " + anim.GetBool("isRunnings"));
        }
        else
        {
            anim.SetBool("isRunnings", false);
        }
        if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            anim.SetBool("isRunnings", false);
        }

        if (Input.GetKey("w") && this.GetComponent<Movement>().isGrounded == true)
        {
            stop();
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
        if (Input.GetKeyUp("w"))
        {
            anim.SetBool("isRunnings", false);
        }

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
