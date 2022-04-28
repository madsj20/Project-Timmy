using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public float timerToNextScene;
    // Start is called before the first frame update
    public void Start()
    {
        timerToNextScene = 28f;
        Invoke("outside", timerToNextScene);
    }

    void outside()
    {
        SceneManager.LoadScene("Outside");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
