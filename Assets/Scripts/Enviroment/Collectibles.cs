using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public GameObject collectibleText;
    //public AudioSource CollectSound;

    private void Start()
    {
        collectibleText.SetActive(false);
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //CollectSound.Play();
            Debug.Log("collected");
            collectibleText.SetActive(true);
            StartCoroutine(Collectible());
            gameObject.SetActive(false);
        }

        
        IEnumerator Collectible()
        {
            yield return new WaitForSeconds(3);
            collectibleText.SetActive(false);
            Debug.Log("collected3");
            Destroy(gameObject);
        }
    }

}
