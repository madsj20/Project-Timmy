using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip UIClick, Crying, Jump, Landing, Hit;
    static AudioSource Audiosrc;
    private AudioController Instance;


    private void Awake()
    {

        Audiosrc = this.GetComponent<AudioSource>();
        Instance = this;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //public static void playSound(string clip) 
    //{
    //    switch (clip)
    //    {
    //        case "UIClick":
    //            Audiosrc.PlayOneShot(UIClick);
    //        break;
    //
    //        case "Crying":
    //            Audiosrc.PlayOneShot(Crying);
    //            break;
    //
    //        case "Jump":
    //            Audiosrc.PlayOneShot(Jump);
    //            break;
    //
    //        case "Landing":
    //            Audiosrc.PlayOneShot(Landing);
    //            break;
    //
    //        case "Hit":
    //            Audiosrc.PlayOneShot(Hit);
    //            Debug.Log("played hit sound");
    //            break;
    //        default:
    //            Debug.Log("Something failed, propobely Mads, just blame him <3");
    //            break;
    //    }
    //}
}
