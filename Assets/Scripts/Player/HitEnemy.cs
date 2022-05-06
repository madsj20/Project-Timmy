using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour
{
    public GameObject hitSquare;
    public bool hasHit;
    public Transform enemy;
    public float angle;
    public Transform rockThrowerTrans;
    // Start is called before the first frame update
    void Start()
    {
        hitSquare = GameObject.Find("HitSquare");
        rockThrowerTrans = GameObject.Find("Rock Thrower").GetComponent<Transform>();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Squirrel")
        {
            //saves the enemys transform
            //enemy = other.GetComponent<Transform>();
            Vector3 dir = other.transform.position - rockThrowerTrans.position;
            dir = other.transform.InverseTransformDirection(dir);
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Debug.Log("Enemy:" + angle);
        }
    }
}
