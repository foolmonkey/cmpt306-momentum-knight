using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManaBar : MonoBehaviour
{
    private PlayerManager playerManager;
    public Slider slider;
    private void Awake()
    {
        playerManager = (PlayerManager)FindObjectOfType(typeof(PlayerManager));
        setMaxMana(playerManager.maxMana);
    }

    private void Update()
    {
        setMana(playerManager.currentMana);
    }

    public void setMana(int mana)
    {
        slider.value = mana;
    }

    public void setMaxMana(int mana)
    {
        slider.maxValue = mana;
        slider.value = mana;
    }
}
