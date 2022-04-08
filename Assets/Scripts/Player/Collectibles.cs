using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{
    public GameObject collectedItem;
    public Sprite currentItem;
    //private string collect;

    

  
    //public AudioSource CollectSound;

    private void Start()
    {
        //Collect = GameObject.FindGameObjectsWithTag("Collectibles");
    }
   


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Collectible"))
        {
            Debug.Log(currentItem);
            //CollectSound.Play();
            Debug.Log("collected");
            currentItem = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            collectedItem.GetComponent<Image>().sprite = currentItem;
            Debug.Log(currentItem);
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
