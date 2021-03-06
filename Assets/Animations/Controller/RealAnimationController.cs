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
    bool soundfall;
    GameObject audios;
    //bool isDying;

    void Awake()
    {
        anim = GetComponent<Animator>();
        grounded = GetComponent<Movement>().isGrounded;
        groundedBush = GetComponent<Movement>().isGroundedBush;
        audios = GameObject.Find("AudioManager");
        isGroundedWallJump = GetComponent<Movement>().isGroundedWallJump;

        soundfall = false;

    }

    public void Update()
    {
        isWall = GetComponent<WallJump>().isWall;
        grounded = GetComponent<Movement>().isGrounded;
        groundedBush = GetComponent<Movement>().isGroundedBush;
        //isDying = this.GetComponent<PlayerPos>().dying;
        //
        //if (isDying == true)
        //{
        //    stop();
        //    anim.enabled = false;
        //    anim.enabled = true;
        //    anim.SetBool("isCrying", true);
        //}
        //else if (isDying == false)
        //{
        //    anim.SetBool("isCrying", false);
        //}

        if (grounded == true || groundedBush == true || isGroundedWallJump == true)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if ((Input.GetKey("a") || (Input.GetKey("d")) || Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.RightArrow))) && grounded)  //&& isDying == false )  //aka se om timmy st�r p� jorden
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

        if (!grounded && !isWall) //isDying == false)
        {
            stop();
            anim.SetBool("isJumping", true);
        }
        else if(anim.GetBool("isJumping") == true && (grounded||isWall))
        {

            if (anim.GetBool("isJumping") && grounded)
            {
                soundfall = true;
            }
            anim.SetBool("isJumping", false);
        }

       

        if (soundfall)
        {
            audios.GetComponent<AudioController>().FallGround();
            soundfall = false;
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
