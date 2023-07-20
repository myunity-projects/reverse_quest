using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    
    public Gradient gradient;

    public Image fill;

    private float startingGradientValue = 1f;

    public void SetMaxHealth(float maxHealth)
    {
        slider.value = maxHealth;
        slider.value = maxHealth;

        fill.color = gradient.Evaluate(startingGradientValue);
    }

    public void SetHealth(float health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
