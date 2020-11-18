using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private string levelSceneName;

    void Awake()
    {
        levelSceneName = "MainMenu";
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // call loader script
            Loader.Load(Loader.Scene.Frost);
        }
    }
}
