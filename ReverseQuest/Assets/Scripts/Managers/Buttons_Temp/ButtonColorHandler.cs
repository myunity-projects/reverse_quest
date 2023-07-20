using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorHandler : MonoBehaviour
{
    private Image buttonImage;
    private Color initialColor;
    private Color pressedColor = Color.red;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        initialColor = buttonImage.color;
    }

    public void OnButtonClick()
    {
        Color colorBlock = buttonImage.color;

        if (colorBlock == initialColor)
        {
            colorBlock = pressedColor;
        }
        else
        {
            colorBlock = initialColor;
        }

        buttonImage.color = colorBlock;
    }
}
