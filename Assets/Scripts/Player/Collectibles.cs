using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{
    public GameObject collectibleText;
    public Text txt;
    //private string collect;

    

  
    //public AudioSource CollectSound;

    private void Start()
    {
        collectibleText.SetActive(false);
        //Collect = GameObject.FindGameObjectsWithTag("Collectibles");
    }
   


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Collectible"))
        {
            
            //CollectSound.Play();
            Debug.Log("collected");
            txt.text = "Det min mors " + collision.gameObject.name + " jeg mistede sidste uge!";
            collectibleText.SetActive(true);
            StartCoroutine(Collectible());
            Destroy(collision.gameObject);
        }

        
        IEnumerator Collectible()
        {
            yield return new WaitForSeconds(3f);
            collectibleText.SetActive(false);
            Debug.Log("collected3");

            
        }
    }

}
