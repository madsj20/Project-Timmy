using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 ogTrans;

    public void Start()
    {
        ogTrans = gameObject.GetComponent<Transform>().position;
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Break());
        }
    }

    IEnumerator Break()
        {
        yield return new WaitForSeconds(1);
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 6;
        StartCoroutine(Respawn());
        }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5);
        gameObject.GetComponent<Transform>().position = ogTrans;
        rb.gravityScale = 0;
        rb.bodyType = RigidbodyType2D.Static;
    }
}
