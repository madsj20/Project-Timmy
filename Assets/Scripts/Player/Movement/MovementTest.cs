using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce = 1;

    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    public bool canMove;
    private bool climb = false;
    public int testCaseJump = 1;
    public int testCaseMove = 1;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        canMove = false;
        Invoke("CanMove", 0f);
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        float dirX = Input.GetAxisRaw("Horizontal");
        if (canMove == true)
        {
            rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);
        }


        //flip player in movement direction
        if (canMove == true)
        {
            if (facingRight == false && dirX < 0)
            {
                Flip();
            }
            else if (facingRight == true && dirX > 0)
            {
                Flip();
            }
        }
    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetButtonDown("Jump") && extraJumps > 0 && canMove == true && climb == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f * jumpForce);
            extraJumps--;
            Debug.Log("Jump");
        }
        else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true && climb == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f * jumpForce);
        }

        //climb script
        if (climb == true && testCaseJump == 1)
        {
            if (Input.GetButton("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, 5f * jumpForce);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.gravityScale = 0;
            }
            if (Input.GetKey("s") && isGrounded == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, -5f * jumpForce);
            }
        }


        //old Climb Script
        if (climb == true && testCaseJump == 2)
        {
            if (Input.GetButton("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, 5f * jumpForce);
            }
        }


        //Choose test case for playtesting
        if (Input.GetKey("1"))
        {
            testCaseJump = 1;
            Debug.Log("Jump Test 1");
        }
        if (Input.GetKey("2"))
        {
            testCaseJump = 2;
            Debug.Log("Jump Test 2");
            rb.gravityScale = 2;
        }

    }
    //Checks if player is inside vine, and activates climb in update
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Vine")
        {
            Debug.Log("Enter vine");
            climb = true;
        }
    }
    //Checks if players has left the vine and disables climbing
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Vine")
        {
            Debug.Log("Left vine");
            climb = false;
            rb.gravityScale = 2;
        }
    }

    //Flip function
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;

        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void CanMove()
    {
        canMove = true;
    }
}
