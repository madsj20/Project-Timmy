using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameObject menu;
    private bool menuToggle;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("Menu");
        menu.SetActive(false);
        menuToggle = false;
    }

    // Update is called once per frame
    void Update()
    {
        //menu toggle
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (menuToggle == false)
            {
                menuToggle = true;
                menu.SetActive(true);
                Time.timeScale = 0;
            }
            else if (menuToggle == true)
            {
                menuToggle = false;
                menu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void Continue()
    {
        menuToggle = false;
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
