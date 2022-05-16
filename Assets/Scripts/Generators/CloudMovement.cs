using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    private float maxVelocity = 2f;
    private float minVelocity = 1f;
    private int lifeTime = 150;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //Destroys cloud after a given time
        Destroy(gameObject, lifeTime);

        rb = gameObject.GetComponent<Rigidbody2D>();
        Vector2 move = new Vector2(Random.Range(-minVelocity, -maxVelocity), rb.rotation);
        rb.velocity = move;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
