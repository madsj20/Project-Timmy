using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    public Rigidbody2D rb;
    private HingeJoint2D hj;
    private BoxCollider2D tim2d;

    public float pushForce = 20f;

    public bool attached = false;
    public Transform attachedTo;
    private GameObject disregard;
    private bool canMove;
    private bool isWall;
    private bool isKnocked;

    Vector2 gamer;

    FallDamage fallDamage;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        hj = gameObject.GetComponent<HingeJoint2D>();
        tim2d = gameObject.GetComponent<BoxCollider2D>();

        fallDamage = GetComponent<FallDamage>();

    }


    void Update()
    {
        isWall = GetComponent<WallJump>().isWall;
        canMove = GetComponent<Movement>().canMove;
        isKnocked = GetComponent<Happiness>().isKnocked;

        if (attached == true)
        {
            fallDamage.airTime = -0;
        }

        CheckInput();
        if (Time.frameCount % 5 == 0)
        {
            GetVelocity();
        }

        if (canMove && !attached && (GetComponent<Movement>().isGrounded == true || GetComponent<Movement>().isGroundedBush == true))
        {
            GetComponent<PlayerSwing>().attachedTo = null;
        }
    }
    void CheckInput()
    {
        if ((Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) && canMove == false && isWall == false)
        {
            if (attached)
            {
                rb.AddRelativeForce(new Vector3(-1, 0, 0) * pushForce);
            }
        }
        if ((Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) && canMove == false && isWall == false)
        {
            if (attached)
            {
                rb.AddRelativeForce(new Vector3(1, 0, 0) * pushForce);
            }
        }
        /*if ((Input.GetKeyDown("s") || Input.GetKeyDown(KeyCode.DownArrow)) && canMove == false && isWall == false)
        {
            //Detatch();
            int index = transform.GetSiblingIndex();
            GameObject nextBrotherNode = transform.parent.GetChild(index + 1).gameObject;
            attachedTo = nextBrotherNode.transform;

        }*/
        if ((Input.GetKeyDown("w")|| Input.GetKeyDown(KeyCode.UpArrow)) && canMove == false && isWall == false)
        {
            Detatch();
            fallDamage.airTime = -0;
            rb.AddForce(transform.up * 12f, ForceMode2D.Impulse);
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
        rb.velocity = new Vector2((gamer.x*4), 0);

        
        
            

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
                        if(GetComponent<Movement>().isGrounded == false && !isWall && !isKnocked) 
                        {
                            
                            Attach(col.gameObject.GetComponent<Rigidbody2D>());
                            //tim2d.isTrigger = true;
                        }
                        
                    }
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {

        if ((Input.GetKeyDown("s") || Input.GetKeyDown(KeyCode.DownArrow)) && canMove == false && isWall == false)
        {
            int index = col.transform.GetSiblingIndex();
            index = index + 1;

            Rigidbody2D gamer = col.transform.parent.GetChild(index+1).gameObject.GetComponent<Rigidbody2D>();
            hj.connectedBody = gamer;

        }
    }

}
