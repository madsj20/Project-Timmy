using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneManagement : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip clickUI;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        clickUI = (AudioClip)Resources.Load("Audio/Sounds/UI/click5");
    }

    public void SceneLoader()
    {
        audioSource.PlayOneShot(clickUI, 1f);
        SceneManager.LoadScene("Classroom");
    }

    public void Exit()
    {
        audioSource.PlayOneShot(clickUI, 1f);
        Application.Quit();
    }
}
