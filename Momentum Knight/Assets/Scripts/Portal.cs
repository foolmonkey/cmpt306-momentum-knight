using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public LevelLoader levelLoader;
    void Awake()
    {
        levelLoader = (LevelLoader)GameObject.FindObjectOfType(typeof(LevelLoader));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            levelLoader.LoadNextLevel();
        }
    }
}
