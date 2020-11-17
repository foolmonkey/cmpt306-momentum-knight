using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI currentHealthText;

    public Slider slider;

    public void setHealth(int health)
    {
        slider.value = health;
        currentHealthText.text = health.ToString();
    }

    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        currentHealthText.text = health.ToString();
    }
}
