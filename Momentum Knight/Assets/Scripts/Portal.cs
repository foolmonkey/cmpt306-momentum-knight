using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private LevelLoader levelLoader;
    void Start()
    {
        levelLoader = (LevelLoader)FindObjectOfType(typeof(LevelLoader));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            levelLoader.LoadNextLevel();
        }
    }
}
