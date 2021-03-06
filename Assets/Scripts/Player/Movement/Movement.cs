using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce = 1;
    GameObject timmy;

    private bool facingRight = true;
    public bool isGrounded;
    public bool isGroundedBush;
    public bool isGroundedWallJump;
    public Transform groundCheck;
    public float checkWidth = 1;
    public float checkHeight = 1;
    public LayerMask whatIsGround;
    public LayerMask spikes;
    public LayerMask wallJump;
    public float dirX;

    private int extraJumps;
    public int extraJumpsValue;

    public bool canMove;
    public bool climb = false;

    public ParticleSystem jumpPS;

    private GameObject audios;

    // Start is called before the first frame update

    private void Awake()
    {
        audios = GameObject.Find("AudioManager");
    }
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        jumpPS = GameObject.Find("Jump Effect").GetComponent<ParticleSystem>();
        canMove = false;
        Invoke("CanMove", 0f);
        timmy = GameObject.Find("Timmy");
        
    }

    // Update is called once per frame
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawCube(groundCheck.position, new Vector2(checkWidth, checkHeight));
    }
    public void FixedUpdate()
    {
        //checks for different kinds of walkable objects
        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(checkWidth, checkHeight), 0, whatIsGround);
        isGroundedBush = Physics2D.OverlapBox(groundCheck.position, new Vector2(checkWidth, checkHeight), 0, spikes);
        isGroundedWallJump = Physics2D.OverlapBox(groundCheck.position, new Vector2(checkWidth, checkHeight), 0, wallJump);

        dirX = Input.GetAxisRaw("Horizontal");
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
        //Debug.Log(isGrounded);
        //checks if player is grounded in any way
        if (isGrounded == true || isGroundedBush == true || isGroundedWallJump == true)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetButtonDown("Jump") && extraJumps > 0 && canMove == true && climb == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f * jumpForce);
            jumpPS.Play();
            extraJumps--;
            Debug.Log("Jump");
            

        }
        else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true && climb == false && canMove == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f * jumpForce);
            jumpPS.Play();
            audios.GetComponent<AudioController>().playJump();
        }

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            //GetComponent<PlayerSwing>().attachedTo = null;
        }

        //climb script
        if (climb == true && GetComponent<Happiness>().isKnocked == false && canMove == true)
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
            if ((Input.GetKey("s")|| Input.GetKey(KeyCode.DownArrow)) /*&& isGrounded == false*/)
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
