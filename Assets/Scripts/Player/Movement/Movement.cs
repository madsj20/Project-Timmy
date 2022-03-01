using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce = 1;
    public bool climb = false;

    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    public bool canMove;

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

        float dirX = Input.GetAxis("Horizontal");
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

        if (Input.GetButtonDown("Jump") && extraJumps > 0 && canMove == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f * jumpForce);
            extraJumps--;
        }
        else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f * jumpForce);
        }

        //climb script
        if (climb == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 5f * jumpForce);
        }

    }
    //Checks if player is inside vine, and activates climb in update
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Vine")
        {
            if (Input.GetButton("Jump"))
            { 
                Debug.Log("Hit vine");
                climb = true;
            }
        }
    }
    //Checks if players has left the vine and disables climbing
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Left vine");
        climb = false;
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
