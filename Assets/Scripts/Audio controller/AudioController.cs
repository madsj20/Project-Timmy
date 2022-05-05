using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioClip UIClick, Crying, Jump, Landing, Hit;
    static AudioSource Audiosrc;

    // Start is called before the first frame update
    void Start()
    {
        UIClick = Resources.Load<AudioClip>("click5");
        Crying = Resources.Load<AudioClip>("Crying-Timmy");
        Jump = Resources.Load<AudioClip>("Crying-Timmy");
        Landing = Resources.Load<AudioClip>("Landing-Timmy");
        Hit = Resources.Load<AudioClip>("Assets/Audio/Sounds/Timmy sounds/Lossing-HP-Timmy.wav");

        Audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void playSound(string clip) 
    {
        switch (clip)
        {
            case "UIClick":
                Audiosrc.PlayOneShot(UIClick);
            break;

            case "Crying":
                Audiosrc.PlayOneShot(Crying);
                break;

            case "Jump":
                Audiosrc.PlayOneShot(Jump);
                break;

            case "Landing":
                Audiosrc.PlayOneShot(Landing);
                break;

            case "Hit":
                Audiosrc.PlayOneShot(Hit);
                Debug.Log("played hit sound");
                break;
            default:
                Debug.Log("Something failed, propobely Mads, just blame him <3");
                break;
        }
    }
}
