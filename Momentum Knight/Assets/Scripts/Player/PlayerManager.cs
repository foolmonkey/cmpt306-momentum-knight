using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform player;
    public bool playerIsMoving;
    private float manaTimer = 0.0f;
    private float manaRegen = 0.2f;
    public int currentHealth;
    public int maxHealth;
    public int currentMana;
    public int maxMana;
    public int currentCoins;
    public LevelLoader LD;

    public void manaDown(int mana)
    {
        SoundManagerScript.PlaySound("playerattack");
        currentMana -= mana;

        if (currentMana < 0)
        {
            currentMana = 0;
        }
    }

    public void healthDown(int health)
    {
        SoundManagerScript.PlaySound("playerhit");
        currentHealth -= health;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public bool addCoin()
    {
        SoundManagerScript.PlaySound("coinpickup");
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
        if (maxMana == 0)
        {
            maxMana = 100;
        }

        currentHealth = maxHealth;
        currentMana = 0;
        currentCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentMana >= 20)
            {
                manaDown(20);
            }
        }

        if (currentMana < maxMana && playerIsMoving)
        {
            manaTimer += Time.deltaTime;
        }
        if (currentMana < maxMana && manaTimer >= manaRegen)
        {
            manaTimer = manaTimer - manaRegen;
            currentMana += 1;
        }

        if(currentHealth == 0)
        {
            Debug.Log("Player Dead");
            LD.LoadSpecificLevel(0);
        }
    }
}
