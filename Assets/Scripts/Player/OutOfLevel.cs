using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfLevel : MonoBehaviour
{
    private Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pos.x < -15)
        {
            GetComponent<Transform>().position = pos;
            Debug.Log("Out of bounds");
        }
    }
}
