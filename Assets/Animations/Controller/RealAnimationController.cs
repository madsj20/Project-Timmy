using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealAnimationController : MonoBehaviour
{
    private Animator anim;
    bool grounded;
    bool groundedBush;
    bool isGroundedWallJump;
    bool isJumping;
    bool isWall;
    GameObject audios;

    void Awake()
    {
        anim = GetComponent<Animator>();
        grounded = GetComponent<Movement>().isGrounded;
        groundedBush = GetComponent<Movement>().isGroundedBush;
        audios = GameObject.Find("AudioManager");
        isGroundedWallJump = GetComponent<Movement>().isGroundedWallJump;
    }

    public void Update()
    {
        isWall = GetComponent<WallJump>().isWall;
        grounded = GetComponent<Movement>().isGrounded;
        groundedBush = GetComponent<Movement>().isGroundedBush;

        if (grounded == true || groundedBush == true || isGroundedWallJump == true)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if ((Input.GetKey("a") || (Input.GetKey("d")) || Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.RightArrow))) && grounded) //aka se om timmy st�r p� jorden
        {
            stop();
            anim.SetBool("isRunnings", true);
            //Debug.Log("isGrounded: " + this.GetComponent<Movement>().isGrounded);
            //Debug.Log("Animation bool: " + anim.GetBool("isRunnings"));
        }
        else
        {
            
            anim.SetBool("isRunnings", false);
        }
        
        /*if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            anim.SetBool("isRunnings", false);
        }*/

        if (!grounded && !isWall)
        {
            stop();
            anim.SetBool("isJumping", true);
        }
        else if(anim.GetBool("isJumping") == true && (grounded||isWall))
        {
            anim.SetBool("isJumping", false);
        }

       


        
        /*if (isWall)
        {
            anim.SetBool("isJumping", false);
        }*/
        
        
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
