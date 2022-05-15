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
    public AudioClip TimCollect;
    public AudioClip BoingEffect;
    public AudioClip TimOof;

    public AudioClip SquirrelOof;

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
        TimCollect = (AudioClip)Resources.Load("Audio/Sounds/TimmySounds/Timmy-Yay");
        BoingEffect = (AudioClip)Resources.Load("Audio/Sounds/TimmySounds/Tim-Boing");
        TimOof = (AudioClip)Resources.Load("Audio/Sounds/TimmySounds/Tim-oof");
        SquirrelOof = (AudioClip)Resources.Load("Audio/Sounds/TimmySounds/SquirrelPain");


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
        audioSource.PlayOneShot(Jump, 0.2f);

    }

    public void FallGround()
    {
      
        audioSource.PlayOneShot(TouchGrass,1f);
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
        audioSource.PlayOneShot(fallingTim, 1f);
        Debug.Log("jeg falder");
        GameObject.FindWithTag("Player").GetComponent<FallDamage>().falling = false;


    }
    public void falldamageOFF()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<FallDamage>().falling = true;
        audioSource.Stop();
        audioSource.PlayOneShot(TouchGrass, 1f);
    }

    public void Collect()
    {
        audioSource.PlayOneShot(TimCollect, 0.5f);

    }

    public void Boing(float jumpvolume)
    {
        //Debug.Log(jumpvolume);
        audioSource.PlayOneShot(BoingEffect, jumpvolume);
    }

    public void Oof()
    {
        audioSource.PlayOneShot(TimOof, 1f);
    }

    public void Sqdeath()
    {
        audioSource.PlayOneShot(SquirrelOof, 0.5f);
    }
}
