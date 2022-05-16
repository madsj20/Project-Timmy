using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointFlags : MonoBehaviour
{
    private int flagNumber;
    public GameObject currentFlag;

    public Sprite flag1;
    public Sprite flag2;
    public Sprite flag3;
    public Sprite flag4;
    public Sprite flag5;

    // Start is called before the first frame update
    void Start()
    {
        currentFlag = GameObject.Find("Checkpoint Image");
    }

    // Update is called once per frame
    void Update()
    {
        switch (flagNumber)
        {
            case 0:
                currentFlag.GetComponent<Image>().sprite = flag1;
                break;
            case 1:
                currentFlag.GetComponent<Image>().sprite = flag2;
                break;
            case 2:
                currentFlag.GetComponent<Image>().sprite = flag3;
                break;
            case 3:
                currentFlag.GetComponent<Image>().sprite = flag4;
                break;
            case 4:
                currentFlag.GetComponent<Image>().sprite = flag5;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Checkpoint 1")
        {
            flagNumber = 0;
        }
        if (other.gameObject.name == "Checkpoint 2")
        {
            flagNumber = 1;
        }
        if (other.gameObject.name == "Checkpoint 3")
        {
            flagNumber = 2;
        }
        if (other.gameObject.name == "Checkpoint 4")
        {
            flagNumber = 3;
        }
        if (other.gameObject.name == "Checkpoint 5")
        {
            flagNumber = 4;
        }
    }
}
