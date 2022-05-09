using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //public AudioClip UIClick, Crying, Jump, Landing, Hit;
    //static AudioSource Audiosrc;
    //private AudioController Instance;
    public AudioSource audioSource;
    public AudioClip Jump;
    public AudioClip clip1;


    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        clip1 = (AudioClip)Resources.Load("Audio/Sounds/TimmySounds/Crying-Timmy");
        Jump = (AudioClip)Resources.Load("Audio/Sounds/TimmySounds/Jumping-Timmy");
        //AudioClip clip2 = Resources.Load<AudioClip>("Sounds/cube_up");
        //AudioClip clip3 = Resources.Load("Sounds/cube_onslot", typeof(AudioClip)) as AudioClip;

        //audioSource.PlayOneShot(clip1);
    }

    public void playJump() 
    {

        audioSource.PlayOneShot(Jump);

    }
}
