using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPMP : MonoBehaviour
{
    public PlayerManager playerManager;

    public HealthBar healthBar;
    public ManaBar manaBar;

    // Start is called before the first frame update
    void Start()
    {
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
