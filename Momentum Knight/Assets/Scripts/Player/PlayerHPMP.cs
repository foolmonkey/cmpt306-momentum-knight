using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPMP : MonoBehaviour
{
    private PlayerManager playerManager;

    public HealthBar healthBar;
    public ManaBar manaBar;

    private void Awake()
    {
        playerManager = (PlayerManager)FindObjectOfType(typeof(PlayerManager));
        healthBar.setMaxHealth(playerManager.maxHealth);
        manaBar.setMaxMana(playerManager.maxMana);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        manaBar.setMana(playerManager.currentMana);
        healthBar.setHealth(playerManager.currentHealth);
    }
}
