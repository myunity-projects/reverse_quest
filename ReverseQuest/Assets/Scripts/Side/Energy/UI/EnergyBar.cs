using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;

    public Image fill;

    private float startingGradientValue = 1f;

    public void SetMaxEnergy(int maxEnergy)
    {
        slider.value = maxEnergy;
        slider.value = maxEnergy;

        fill.color = gradient.Evaluate(startingGradientValue);
    }

    public void SetEnergy(int energy)
    {
        slider.value = energy;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
