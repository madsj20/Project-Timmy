using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCollectibleEndScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        for (int i = 0; i < Collectibles.Collected.Count; i++)
        {
            if (Collectibles.Collected[i] == gameObject.GetComponent<SpriteRenderer>().sprite.name)
            {
                gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
