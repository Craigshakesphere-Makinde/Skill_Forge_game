using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;

    public Image fill;
    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);

    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        gradient.Evaluate(1f);
    }

}
