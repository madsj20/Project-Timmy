using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSegment : MonoBehaviour
{
    public GameObject connectedAbove, connectedBelow;
    public bool isPlayerAttached;

    public bool straight = true;


    private void Awake()
    {
        ;
    }

    void Start()
    {
        straight = true;
        connectedAbove = GetComponent<HingeJoint2D>().connectedBody.gameObject;
        RopeSegment aboveSegment = connectedAbove.GetComponent<RopeSegment>();
        if (aboveSegment != null)
        {
            aboveSegment.connectedBelow = gameObject;
            float spriteBottom = connectedAbove.GetComponent<SpriteRenderer>().bounds.size.y;
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, spriteBottom*-1);
        }
        else
        {
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, 0);
        }

        
    }
    private void Update()
    {
        if(!straight && GameObject.FindWithTag("Player").GetComponent<PlayerSwing>().attached == false)
        {
            straight = true;
            CancelInvoke();
            Invoke("reset", 5f);
            Debug.Log("kører");
        }

        if (GameObject.FindWithTag("Player").GetComponent<PlayerSwing>().attached == true)
        {
            CancelInvoke();
        }

    }
    void reset()
    {
        Debug.Log("reset");
        
        
        GetComponentInParent<Rope>().reset();
        CancelInvoke();


    }


}
