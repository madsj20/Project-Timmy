using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyStick : MonoBehaviour
{
    private float root;
    private float timmyRoot;
    private GameObject timmy;
    private float distance;
    private float branchWidth;

    private float normDistance;
    private float timmyVelocity;
    private float timmyVelocitized;
    public float bounceForce ;
    public float bounceFactor;

    Vector2 timRB;

    private bool running;

    GameObject audios;
    
    public void Awake()
    {
        audios = GameObject.Find("AudioManager");
        timmy = GameObject.FindWithTag("Player");
        branchWidth = GetComponent<Collider2D>().bounds.size.x;

    }
    private void Start()
    {
        //Debug.Log(root);
        running = true;
    }

    private void Update()
    {
        //timmyVelocity = timmy.GetComponent<Rigidbody2D>().velocity.magnitude;
        //timRB = timmy.GetComponent<Rigidbody2D>().velocity;
        

        if (Time.frameCount % 5 == 0)
        {
            GetVelocity();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audios.GetComponent<AudioController>().playJump();
            timmyRoot = timmy.transform.position.x;
            root = this.gameObject.transform.GetChild(0).position.x;
            distance = Mathf.Abs(timmyRoot - root);
            //Mathf.InverseLerp(0, 1, distance);
            normDistance = Mathf.InverseLerp(0, branchWidth, distance);
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * (normDistance * bounceForce * timmyVelocity), ForceMode2D.Impulse);
            //StartCoroutine(GetVelocity());
            if (running)
            {
                
                StartCoroutine(JumpPause());
            }

            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * (normDistance * bounceForce), ForceMode2D.Impulse);
            if (timmy.GetComponent<Rigidbody2D>().velocity.magnitude > 20f)
            {
                timmy.GetComponent<Rigidbody2D>().velocity = timmy.GetComponent<Rigidbody2D>().velocity.normalized * 20f;
            }
            Debug.Log(Mathf.InverseLerp(0, branchWidth, distance));
        }
    }
   IEnumerator JumpPause()
    {
        running = false;
        timmy.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * (normDistance * bounceForce * (timmyVelocitized+1) * bounceFactor), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        running = true;
    }

    /*IEnumerator GetVelocity()
    {

        yield return new Wait
        timmyVelocity = timmy.GetComponent<Rigidbody2D>().velocity.magnitude;
    }*/

    public void GetVelocity()
    {
        timmyVelocity = timmy.GetComponent<Rigidbody2D>().velocity.magnitude;
        timmyVelocitized = Mathf.InverseLerp(5, 30, timmyVelocity);




        //Debug.Log(Mathf.InverseLerp(0, 20, timmyVelocity));
    }

}
