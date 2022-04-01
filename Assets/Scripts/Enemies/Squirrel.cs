using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour
{
    public bool canMove;
    private bool facingRight = true;
    Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private int dirX = 1;
    public float speed = 2f;
    private bool flipPause = false;
    public float deathForce = 4;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = false;
        Invoke("CanMove", 0f);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
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

        if (isGrounded == false && flipPause == false && canMove == true)
        {
            StartCoroutine(FlipPause());
        }
    }
    //Squirrel death
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HitSquare")
        {
            //Makes squirrel go through floor
            canMove = false;
            GetComponent<Collider2D>().enabled = false;
            rb.AddForce(transform.up * deathForce, ForceMode2D.Impulse);
            GetComponent<Rigidbody2D>().freezeRotation = false;
            rb.AddTorque(360, ForceMode2D.Impulse);
        }
    }

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

    IEnumerator FlipPause()
    {
        flipPause = true;
        dirX = dirX * -1;
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        //adds delay so the squrrel does not turn around instantly again
        yield return new WaitForSeconds(0.2f);
        flipPause = false;
    }
}
