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
        Timmy.gravityScale = 0;
        Timmy.mass = 0;
        GetComponent<Movement>().canMove = false;
        yield return new WaitForSeconds(2f);
        Timmy.gravityScale = 4;
        Timmy.mass = 1;
        Timmy.AddForce(transform.up * 40f, ForceMode2D.Impulse);
        GetComponent<Movement>().canMove = true;
    }
}
