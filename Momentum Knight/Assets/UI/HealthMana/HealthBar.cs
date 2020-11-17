using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class HealthBar : MonoBehaviour
{
    public PlayerManager playerManager;
    public TextMeshProUGUI currentHealthText;

    public Slider slider;

    private void Awake()
    {
        playerManager = (PlayerManager)FindObjectOfType(typeof(PlayerManager));
        setMaxHealth(playerManager.maxHealth);
    }

    private void Update()
    {
        setHealth(playerManager.currentHealth);
    }

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
