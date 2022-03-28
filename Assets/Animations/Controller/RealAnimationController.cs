using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealAnimationController : MonoBehaviour
{
    private Animator anim;
    bool grounded;
    bool isJumping;

    void Awake()
    {
        anim = GetComponent<Animator>();
        grounded = GetComponent<Movement>().isGrounded;
        
    }

    public void Update()
    {
        grounded = GetComponent<Movement>().isGrounded;
        if ((Input.GetKey("a") || (Input.GetKey("d"))) && grounded) //aka se om timmy står på jorden
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
        
        /*if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            anim.SetBool("isRunnings", false);
        }*/

        if (!grounded)
        {
            stop();
            anim.SetBool("isJumping", true);
        }
        else if(anim.GetBool("isJumping") == true && grounded)
        {
            anim.SetBool("isJumping", false);
        }
        
        
        
        /*if(grounded)
        {
            stop();
            anim.SetBool("isJumping", false);
        }*/

        /*if (Input.GetKeyUp("w"))
        {
            anim.SetBool("isRunnings", false);
        }*/

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
