using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Enemy
{
    public GameObject birdShit;
    public float changeDirTime = 5f;
    public float shitTime = 2.5f;

    // Start is called before the first frame update
    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeDir());
        StartCoroutine(SpawnShit());
    }

    IEnumerator ChangeDir()
    {
        yield return new WaitForSeconds(changeDirTime);
        dirX = dirX * -1;
        StartCoroutine(ChangeDir());
    }

    IEnumerator SpawnShit()
    {
        yield return new WaitForSeconds(shitTime);
        Instantiate(birdShit, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        StartCoroutine(SpawnShit());
    }
}
