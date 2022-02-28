using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(player.position.x, player.position.y, this.transform.position.z);

    }
}
