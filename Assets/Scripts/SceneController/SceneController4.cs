using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController4 : MonoBehaviour
{
    bool win;

    // Start is called before the first frame update
    public void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            win = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (win == true)
        {
            SceneManager.LoadScene("GettingTheFrisbee");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("GettingTheFrisbee");
        }
    }
}
