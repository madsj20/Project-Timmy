using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{
    public GameObject collectedItem;
    public Sprite currentItem;
    public GameObject currentOwner;
    private GameObject speachBubble;

    public Sprite jerome;
    public Sprite child1;
    public Sprite child2;
    public Sprite child3;
    public Sprite timmy;

    private bool bubbleToPos = false;
    public float speed = 8;
    private int childNumber = 0;

    //private string collect;




    //public AudioSource CollectSound;

    private void Start()
    {
        //Collect = GameObject.FindGameObjectsWithTag("Collectibles");
        speachBubble = GameObject.Find("Collectibles Speach Bubble");
    }

    private void Update()
    {
        switch (childNumber)
        {
            case 0:
                currentOwner.GetComponent<Image>().sprite = jerome;
                break;
            case 1:
                currentOwner.GetComponent<Image>().sprite = child2;
                break;
            case 2:
                currentOwner.GetComponent<Image>().sprite = child1;
                break;
            case 3:
                currentOwner.GetComponent<Image>().sprite = child3;
                break;
        }

        //Lerp has to be in a loop to work, therefore i use at bool to activate it
        if(bubbleToPos == true)
        {
            speachBubble.GetComponent<Transform>().position = Vector2.Lerp(speachBubble.GetComponent<Transform>().position, new Vector2(105f, 50), Time.deltaTime * speed);
        }

        if(bubbleToPos == false)
        {
            speachBubble.GetComponent<Transform>().position = Vector2.Lerp(speachBubble.GetComponent<Transform>().position, new Vector2(105f, -50), Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            //CollectSound.Play();
            childNumber = Random.Range(0, 4);
            StartCoroutine(Collectible());
            Debug.Log("collected");
            currentItem = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            collectedItem.GetComponent<Image>().sprite = currentItem;
            Destroy(collision.gameObject);
            bubbleToPos = true;
        }
        
        IEnumerator Collectible()
        {
            yield return new WaitForSeconds(3f);
            bubbleToPos = false;

        }
    }

}
