using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool canMove = true;
    public float deathForce = 4;
    protected float speed = 2f;
    private float deathTimer;

    protected int dirX = 1;
    protected bool facingRight = true;

    GameObject audios;

    private void Awake()
    {
        audios = GameObject.Find("AudioManager");
    }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = false;
        Invoke("CanMove", 0f);
    }

    protected virtual void Update()
    {
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        //flip enemy in movement direction
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

    //Squirrel death
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("HitSquare"))
        {
            deathTimer = 0.4f;
            StartCoroutine(EnemyDeath());
        }
        if (other.gameObject.CompareTag("Rock"))
        {
            deathTimer = 0;
            StartCoroutine(EnemyDeath());
        }
    }

    protected void CanMove()
    {
        canMove = true;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;

        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    IEnumerator EnemyDeath()
    {
        audios.GetComponent<AudioController>().Sqdeath();
        yield return new WaitForSeconds(deathTimer);
        //Makes squirrel go through floor
        canMove = false;
        GetComponent<Rigidbody2D>().gravityScale = 1;
        GetComponent<Collider2D>().enabled = false;
        rb.AddForce(transform.up * deathForce, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().freezeRotation = false;
        rb.constraints = (RigidbodyConstraints2D)RigidbodyConstraints.FreezeRotationY;
        rb.AddTorque(360, ForceMode2D.Impulse);
    }
}
