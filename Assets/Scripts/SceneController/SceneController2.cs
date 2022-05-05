using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController2 : MonoBehaviour
{
    public float timerToNextScene1;
    // Start is called before the first frame update
    public void Start()
    {
        timerToNextScene1 = 51;
        Invoke("Play", timerToNextScene1);
    }

    void Play()
    {
        SceneManager.LoadScene("PlayScene");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
