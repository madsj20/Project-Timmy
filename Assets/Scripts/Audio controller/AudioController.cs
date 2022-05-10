using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //public AudioClip UIClick, Crying, Jump, Landing, Hit;
    //static AudioSource Audiosrc;
    //private AudioController Instance;
    public AudioSource audioSource;
    private AudioSource childsource;
    public AudioClip Jump;
    public AudioClip clip1;
    public AudioClip TouchGrass;
    public AudioClip fallingTim;

    public AudioClip backgrounds;

    public void Awake()
    {
        childsource = gameObject.transform.GetChild(0).GetComponent<AudioSource>();

      

        audioSource = GetComponent<AudioSource>();
        clip1 = (AudioClip)Resources.Load("Audio/Sounds/TimmySounds/Crying-Timmy");
        Jump = (AudioClip)Resources.Load("Audio/Sounds/TimmySounds/Jumping-Timmy");
        TouchGrass = (AudioClip)Resources.Load("Audio/Sounds/TimmySounds/Landing-Timmy");
        backgrounds = (AudioClip)Resources.Load("Audio/Sounds/TimmySounds/Timmy-Music");
        fallingTim = (AudioClip)Resources.Load("Audio/Sounds/TimmySounds/Falling-Damage");
        //AudioClip clip2 = Resources.Load<AudioClip>("Sounds/cube_up");
        //AudioClip clip3 = Resources.Load("Sounds/cube_onslot", typeof(AudioClip)) as AudioClip;

        //audioSource.PlayOneShot(clip1);
    }
    public void Start()
    {
        
        background();
    }

    public void playJump() 
    {
        audioSource.volume = 0.2f;
        audioSource.PlayOneShot(Jump);

    }

    public void FallGround()
    {
        audioSource.volume = 1f;
        audioSource.PlayOneShot(TouchGrass);
    }

    public void background()
    {
        
        childsource.loop = true;
        childsource.clip = backgrounds;
        childsource.volume = 0.1f;
        childsource.Play();
    }

    public void falldamageON()
    {
        audioSource.PlayOneShot(fallingTim);
        Debug.Log("jeg falder");
        GameObject.FindWithTag("Player").GetComponent<FallDamage>().falling = false;
        audioSource.volume = 1f;
        

        /*audioSource.clip = fallingTim;
        audioSource.volume = 1f;
        audioSource.Play();*/

    }
    public void falldamageOFF()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<FallDamage>().falling = true;
        audioSource.Stop();
        audioSource.PlayOneShot(TouchGrass);
    }

}
