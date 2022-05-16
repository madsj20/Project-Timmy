using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatteliteCreator : MonoBehaviour
{

    public float satteliteMin = -4;
    public float satteliteMax = 4;
    public float spawnRate = 8;
    private int randomSattelite;
    public GameObject sattelite1;
    public GameObject sattelite2;
    public GameObject sattelite3;
    public bool spawnsattelite = true;


    private void Start()
    {
        Invoke("InstantiateSattelite", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnsattelite == true)
        {
            spawnsattelite = false;
            Invoke("InstantiateSattelite", spawnRate);
        }
    }

    void InstantiateSattelite()
    {
        //Creates a random sattelite every second
        randomSattelite = Random.Range(1, 4);
        switch (randomSattelite)
        {
            case 1:
                Instantiate(sattelite1, transform.position + transform.up * Random.Range(satteliteMin, satteliteMax), transform.rotation);
                break;
            case 2:
                Instantiate(sattelite2, transform.position + transform.up * Random.Range(satteliteMin, satteliteMax), transform.rotation);
                break;
            case 3:
                Instantiate(sattelite3, transform.position + transform.up * Random.Range(satteliteMin, satteliteMax), transform.rotation);
                break;
        }

        spawnsattelite = true;
    }

}
