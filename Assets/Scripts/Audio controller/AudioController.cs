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

    public static void playSound() 
    {
        AudioClip[] audioClips;
        
    }
}
