using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crying : MonoBehaviour
{
    private Animator anim;
    GameObject Timmy;
    Rigidbody2D rb;
    Rigidbody2D timrb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Timmy = GameObject.Find("Timmy");
        rb = gameObject.GetComponent<Rigidbody2D>();
        timrb = Timmy.GetComponent<Rigidbody2D>();
        
    }


    public void OnEnable()
    {
        //anim.SetBool("isCrying", true);
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        timrb.constraints = RigidbodyConstraints2D.FreezeAll;

    }
    private void OnDisable()
    {
        gameObject.transform.position = Timmy.transform.position;
        timrb.constraints = RigidbodyConstraints2D.None;
        timrb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
