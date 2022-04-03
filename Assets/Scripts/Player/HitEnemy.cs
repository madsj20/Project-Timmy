using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour
{
    public GameObject hitSquare;
    public bool hasHit;
    // Start is called before the first frame update
    void Start()
    {
        hitSquare = GameObject.Find("HitSquare");
        hasHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && hasHit == false)
        {
            hasHit = true;
            StartCoroutine(HitCooldown());
        }
    }

    IEnumerator HitCooldown()
    {
        hitSquare.GetComponent<SpriteRenderer>().enabled = true;
        hitSquare.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        hitSquare.GetComponent<SpriteRenderer>().enabled = false;
        hitSquare.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        hasHit = false;
    }
}
