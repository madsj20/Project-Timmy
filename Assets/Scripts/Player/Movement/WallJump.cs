using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpSpeed;
    private float walkSpeed;
    private bool isGrounded;
    public LayerMask groundMask;
    private float moveInput;
    private bool isRight;
    private bool isLeft;
    private bool wallJumping;
    private float leftOrRight;
    
    public bool isWall;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //groundMask = GetComponent<Movement>().whatIsGround;
        walkSpeed = 10f;
        //jumpSpeed = GetComponent<Movement>().jumpForce;
        jumpSpeed = 10f;
    }
    void Update()
    {
        //isGrounded = GetComponent<Movement>().isGrounded;

        isLeft = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x -0.25f, gameObject.transform.position.y + 0.8f),
        new Vector2(0.1f, 1.2f), 0f, groundMask);

        isRight = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x +0.25f, gameObject.transform.position.y + 0.8f),
        new Vector2(0.1f, 1.2f), 0f, groundMask);

        if (isLeft)
        {
            leftOrRight = 1;
            isWall = true;
        }
        else if  (isRight)
        {
            leftOrRight = -1;
            isWall = true;
        }
        else
        {
            isWall = false;
        }

        if ((Input.GetKeyDown("w") || Input.GetKeyDown(KeyCode.UpArrow)) && (isLeft || isRight) /*&& !isGrounded*/)
        {
            
            wallJumping = true;
            Invoke("SetJumpingToFalse", 0.3f);
        }

        if (wallJumping)
        {
            GetComponent<Movement>().canMove = false;
            rb.velocity = new Vector2(walkSpeed * leftOrRight, jumpSpeed);
        }
        
    }
    void OnDrawGizmosSelected()
    {
       

        Gizmos.color = Color.blue;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x -0.25f, gameObject.transform.position.y+0.8f), new Vector2(0.1f, 1.2f));

        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x +0.25f, gameObject.transform.position.y+0.8f), new Vector2(0.1f, 1.2f));
    }

    void SetJumpingToFalse()
    {
        wallJumping = false;
        GetComponent<Movement>().canMove = true;
        
    }
}