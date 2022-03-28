using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCreater : MonoBehaviour
{

    public float cloudMin = -2;
    public float cloudMax = 2;
    private float spawnRate = 6;
    private int randomCloud;
    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject cloud3;
    public GameObject cloud4;
    public GameObject cloud5;
    public bool spawnCloud = true;


    // Update is called once per frame
    void Update()
    {
        if (spawnCloud == true)
        {
            spawnCloud = false;
            Invoke("instantiateCloud", spawnRate);
        }
    }

    void instantiateCloud()
    {
        //Creates a random cloud every secon
        randomCloud = Random.Range(1, 6);
        switch (randomCloud)
        {
            case 1:
                Instantiate(cloud1, transform.position + transform.up * Random.Range(cloudMin, cloudMax), transform.rotation);
                break;
            case 2:
                Instantiate(cloud2, transform.position + transform.up * Random.Range(cloudMin, cloudMax), transform.rotation);
                break;
            case 3:
                Instantiate(cloud3, transform.position + transform.up * Random.Range(cloudMin, cloudMax), transform.rotation);
                break;
            case 4:
                Instantiate(cloud4, transform.position + transform.up * Random.Range(cloudMin, cloudMax), transform.rotation);
                break;
            case 5:
                Instantiate(cloud5, transform.position + transform.up * Random.Range(cloudMin, cloudMax), transform.rotation);
                break;
        }

        spawnCloud = true;
    }

}
