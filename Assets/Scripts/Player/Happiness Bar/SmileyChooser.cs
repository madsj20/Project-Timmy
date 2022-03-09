using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmileyChooser : MonoBehaviour
{
    public Sprite happySmiley;
    public Sprite neutralSmiley;
    public Sprite sadSmiley;
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        ChangeImage();
    }

    void ChangeImage()
    {
        if (slider.value > 50)
        {
            gameObject.GetComponent<Image>().sprite = happySmiley;
        }
        if (slider.value < 50 && slider.value > 25)
        {
            gameObject.GetComponent<Image>().sprite = neutralSmiley;
        }
        if (slider.value < 25)
        {
            gameObject.GetComponent<Image>().sprite = sadSmiley;
        }
    }
}
