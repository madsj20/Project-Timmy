using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce = 1;

    private bool facingRight = true;
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    public bool canMove;
    private bool climb = false;

    public ParticleSystem jumpPS;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        jumpPS = GameObject.Find("Jump Effect").GetComponent<ParticleSystem>();
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
        if (Input.GetButtonDown("Jump") && extraJumps > 0 && canMove == true && climb == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f * jumpForce);
            jumpPS.Play();
            extraJumps--;
            Debug.Log("Jump");
        }
        else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true && climb == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f * jumpForce);
            jumpPS.Play();
        }

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            //GetComponent<PlayerSwing>().attachedTo = null;
        }

        //climb script
        if (climb == true)
        {
            if (Input.GetButton("Jump"))
            {
                rb.velocity = new Vector2(rb.velocity.x, 5f);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.gravityScale = 0;
            }
            if (Input.GetKey("s") && isGrounded == false)
            {
                rb.velocity = new Vector2(rb.velocity.x, -5f);
            }
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
            rb.gravityScale = 4;
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
