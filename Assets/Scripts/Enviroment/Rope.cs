using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Rope : MonoBehaviour
{ 
    public Rigidbody2D hook;
    public GameObject[] prefabRopeSegs;
    public int numLinks = 5;

     

    void Start()
    {
        GenerateRope();
    }
    void GenerateRope()
    {
        Rigidbody2D prevBod = hook;
        for (int i = 0; i < numLinks; i ++)
        {
            int index = Random.Range(0, prefabRopeSegs.Length);
            GameObject newSeg = Instantiate(prefabRopeSegs[index]);
            newSeg.transform.parent = transform;
            newSeg.transform.position = transform.position;
            HingeJoint2D hj = newSeg.GetComponent<HingeJoint2D>();
            hj.connectedBody = prevBod;

            prevBod = newSeg.GetComponent<Rigidbody2D>();
        }



    }
    public void reset()
    {
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            Transform child = transform.GetChild(i);
            child.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            child.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            child.localPosition = Vector3.zero;
            child.localEulerAngles = Vector3.zero;
            
        }

    }
}