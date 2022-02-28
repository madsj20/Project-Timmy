using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce = 1;

    private bool facingRight1 = false;
    private bool facingRight2 = true;
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
        Invoke("CanMove", 1.5f);
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
            if (facingRight2 == false && dirX > 0)
            {
                Flip();
            }
            else if (facingRight2 == true && dirX < 0)
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
    }

    //Flip function
    void Flip()
    {
            facingRight2 = !facingRight2;
            Vector3 Scaler = transform.localScale;

            Scaler.x *= -1;
            transform.localScale = Scaler;
    }

    public void CanMove()
    {
        canMove = true;
    }
}
