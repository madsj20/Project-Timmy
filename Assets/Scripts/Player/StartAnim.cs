using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnim : MonoBehaviour
{
    public bool Starting;
    Rigidbody2D Timmy;
    float timgrav;
    // Start is called before the first frame update
   
    void Awake()
    {
        //timgrav = Timmy.gravityScale;
        Timmy = GetComponent<Rigidbody2D>();
        
         
        
    }
    private void Start()
    {
        Timmy.gravityScale = 0;
        Timmy.mass = 0;
    }
    private void Update()
    {
        if (Starting)
        {
            //Debug.Log("hej");
            StartCoroutine(AnimStarter());
            Starting = false;
        }
    }

    IEnumerator AnimStarter()
    {
        GetComponent<Movement>().canMove = false;
       
        Timmy.gravityScale = 4;
        Timmy.mass = 1;
        Timmy.AddForce(transform.up * 35f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        GetComponent<Movement>().canMove = true;
    }
}
