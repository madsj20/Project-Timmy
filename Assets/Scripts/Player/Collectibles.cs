using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{
    public GameObject collectedItem;
    public Sprite currentItem;
    public GameObject currentOwner;

    public Sprite jerome;
    public Sprite child1;
    public Sprite child2;
    public Sprite child3;
    public Sprite Timmy;
    //private string collect;




    //public AudioSource CollectSound;

    private void Start()
    {
        //Collect = GameObject.FindGameObjectsWithTag("Collectibles");
    }

    private void Update()
    {
        switch (currentItem.name)
        {
            case "Bicycle":
                currentOwner.GetComponent<Image>().sprite = jerome;
                break;
            case "Red-White Shoe":
                currentOwner.GetComponent<Image>().sprite = child2;
                break;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Collectible"))
        {
            //CollectSound.Play();
            Debug.Log("collected");
            currentItem = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            collectedItem.GetComponent<Image>().sprite = currentItem;
            StartCoroutine(Collectible());
            Destroy(collision.gameObject);
        }

        
        IEnumerator Collectible()
        {
            yield return new WaitForSeconds(3f);
            Debug.Log("collected3");

            
        }
    }

}
