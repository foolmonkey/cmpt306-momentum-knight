﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform player;
    public int currentHealth;
    public int maxHealth;
    public int currentMana;
    public int maxMana;

    public int currentCoins;

    public void manaDown(int mana)
    {
        currentMana -= mana;

        if (currentMana < 0)
        {
            currentMana = 0;
        }
    }

    public void healthDown(int health)
    {
        currentHealth -= health;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public bool addCoin()
    {
        currentCoins++;
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (maxHealth == 0)
        {
            maxHealth = 100;
        }
        currentHealth = maxHealth;
        if (maxMana == 0)
        {
            maxMana = 100;
        }
        currentMana = maxMana;
        currentCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
