using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    public Rigidbody2D rb;
    private HingeJoint2D hj;

    public float pushForce = 10f;

    public bool attached = false;
    public Transform attachedTo;
    private GameObject disregard;


    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        hj = gameObject.GetComponent<HingeJoint2D>();
    }


    void Update()
    {
        CheckInput();
    }
    void CheckInput()
    {
        if (Input.GetKey("a"))
        {
            if (attached)
            {
                rb.AddRelativeForce(new Vector3(-1, 0, 0) * pushForce);
            }
        }
        if (Input.GetKey("d"))
        {
            if (attached)
            {
                rb.AddRelativeForce(new Vector3(1, 0, 0) * pushForce);
            }
        }
        if (Input.GetKeyDown("s"))
        {
            Detatch();
        }
        if (Input.GetKeyDown("w"))
        {
            Detatch();
            rb.velocity = new Vector2(rb.velocity.x, 8f);
        }
        
    }
    public void Attach(Rigidbody2D ropeBone)
    {
        GetComponent<Movement>().canMove = false;
        ropeBone.gameObject.GetComponent<RopeSegment>().isPlayerAttached = true;
        hj.connectedBody = ropeBone;
        hj.enabled = true;
        attached = true;
        attachedTo = ropeBone.gameObject.transform.parent;

    }
    void Detatch()
    {
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
                        Attach(col.gameObject.GetComponent<Rigidbody2D>());
                    }
                }
            }
        }
    }


}
