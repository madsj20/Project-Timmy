using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private float destroyTimer = 10;

    void Update()
    {
        GetComponent<Rigidbody2D>().AddTorque(5f);
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(gameObject);
    }
}
