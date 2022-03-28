using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdShit : MonoBehaviour
{
    private bool iShit;
    private bool cooldown;
    private int shitTimer = 3;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        iShit = true;
        cooldown = true;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shitTimer == 0)
        {
            //iShit = false;
            Destroy(gameObject);
        } 
        
        if (iShit && cooldown)
        {
            StartCoroutine(BTimer());
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Platform"))
        {
            //Debug.Log("i am running");

            gameObject.transform.parent = other.transform;
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            shitTimer = 5;
        }
    }

    

    IEnumerator BTimer()
    {
        //Debug.Log("i am running");
        cooldown = false;
        shitTimer--;
        yield return new WaitForSeconds(1f);
        cooldown = true;
       

    }
}
