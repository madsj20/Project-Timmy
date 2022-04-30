using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{

    public void SceneLoader()
    {
        SceneManager.LoadScene("Classroom");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
