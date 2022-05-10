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
    private Vector2 SpeachBubbleFinalTrans;
    public static List<GameObject> collectedItems = new List<GameObject>();

    public Sprite jerome;
    public Sprite child1;
    public Sprite child2;
    public Sprite child3;
    public Sprite timmy;

    private Transform collectedItemsTrans;

    private bool bubbleToPos = false;
    public float speed = 8;
    private int childNumber = 0;
    private Vector2 speachBubbleTrans;

    //private string collect;




    //public AudioSource CollectSound;

    private void Start()
    {
        //Collect = GameObject.FindGameObjectsWithTag("Collectibles");
        speachBubble = GameObject.Find("Collectibles Speach Bubble");
        speachBubbleTrans = speachBubble.GetComponent<RectTransform>().position;
        SpeachBubbleFinalTrans = GameObject.Find("Speach Bubble Transform").GetComponent<RectTransform>().position;
        collectedItemsTrans = GameObject.Find("Collected Items Transform").GetComponent<Transform>();
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
            speachBubble.GetComponent<RectTransform>().position = Vector2.Lerp(speachBubble.GetComponent<RectTransform>().position, new Vector2(speachBubbleTrans.x, SpeachBubbleFinalTrans.y), Time.deltaTime * speed);
        }

        if(bubbleToPos == false)
        {
            speachBubble.GetComponent<RectTransform>().position = Vector2.Lerp(speachBubble.GetComponent<RectTransform>().position, speachBubbleTrans, Time.deltaTime * speed);
        }

        //Prints Collected Items
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            for (int i = 0; i < collectedItems.Count; i++)
            {
                Debug.Log(collectedItems[i]);
                Instantiate(collectedItems[i], collectedItemsTrans);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            //CollectSound.Play();
            GetComponent<Happiness>().GiveHappiness(50);
            childNumber = Random.Range(0, 4);
            StartCoroutine(Collectible());
            Debug.Log("collected");
            currentItem = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            //Adds collected item to list
            collectedItems.Add(collision.gameObject);
            collectedItem.GetComponent<Image>().sprite = currentItem;
            //Moves gameobject out of view
            collision.gameObject.GetComponent<Transform>().position = new Vector2(-50, 0);
            //Destroy(collision.gameObject);
            bubbleToPos = true;
        }
        
        IEnumerator Collectible()
        {
            yield return new WaitForSeconds(3f);
            bubbleToPos = false;

        }
    }

}
