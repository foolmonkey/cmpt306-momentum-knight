using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPMP : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int maxMana = 50;
    public int currentMana;

    public HealthBar healthBar;
    public ManaBar manaBar;

    void useMana(int mana){
        currentMana -= mana;

        manaBar.setMana(currentMana);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        healthBar.setHealth(maxHealth);
        
        currentMana = maxMana;
        manaBar.setMaxMana(maxMana);
        manaBar.setMana(maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
                useMana(10);
        }   
    }
}
