using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    public Rigidbody2D rb;
    private HingeJoint2D hj;
    private BoxCollider2D tim2d;

    public float pushForce = 10f;

    public bool attached = false;
    public Transform attachedTo;
    private GameObject disregard;
    private bool canMove;

    Vector2 gamer;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        hj = gameObject.GetComponent<HingeJoint2D>();
        tim2d = gameObject.GetComponent<BoxCollider2D>();
        canMove = GetComponent<Movement>().canMove;
    }


    void Update()
    {
        CheckInput();
        if (Time.frameCount % 5 == 0)
        {
            GetVelocity();
        }
    }
    void CheckInput()
    {
        if (Input.GetKey("a") && canMove == false)
        {
            if (attached)
            {
                rb.AddRelativeForce(new Vector3(-1, 0, 0) * pushForce);
            }
        }
        if (Input.GetKey("d") && canMove == false)
        {
            if (attached)
            {
                rb.AddRelativeForce(new Vector3(1, 0, 0) * pushForce);
            }
        }
        if (Input.GetKeyDown("s") && canMove == false)
        {
            Detatch();
        }
        if (Input.GetKeyDown("w") && canMove == false)
        {
            Detatch();
            rb.velocity = new Vector2(rb.velocity.x, 14f);
        }
        
    }
    void GetVelocity()
    {
        gamer = rb.velocity;
    }
    public void Attach(Rigidbody2D ropeBone)
    {
        
        GetComponent<Movement>().canMove = false;
        ropeBone.gameObject.GetComponent<RopeSegment>().isPlayerAttached = true;
        hj.connectedBody = ropeBone;
        hj.enabled = true;
        attached = true;
        attachedTo = ropeBone.gameObject.transform.parent;
        rb.velocity = new Vector2((gamer.x*2), 0);
        

    }
    void Detatch()
    {
        tim2d.isTrigger = false;
        GetComponent<Movement>().canMove = true;
        hj.connectedBody.gameObject.GetComponent<RopeSegment>().isPlayerAttached = false;
        attached = false;
        hj.enabled = false;
        hj.connectedBody = null;
        //StartCoroutine(AttachedNull());
    }

    /*IEnumerator AttachedNull()
    {
        yield return new WaitForSeconds(0.5f);
        attachedTo = null;
    }*/

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!attached)
        {
            if(col.gameObject.tag == "Rope")
            {
                if(attachedTo != col.gameObject.transform.parent)
                {
                    if(disregard == null || col.gameObject.transform.parent.gameObject != disregard)
                    {
                        if(GetComponent<Movement>().isGrounded == false) 
                        {
                            
                            Attach(col.gameObject.GetComponent<Rigidbody2D>());
                            tim2d.isTrigger = true;
                        }
                        
                    }
                }
            }
        }
    }


}
