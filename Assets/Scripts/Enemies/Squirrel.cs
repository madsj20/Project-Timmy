using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : Enemy
{
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool flipPause = false;

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (isGrounded == false && flipPause == false && canMove == true)
        {
            StartCoroutine(FlipPause());
        }
        base.Update();
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
