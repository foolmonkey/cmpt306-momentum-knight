using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame(){
        Loader.Load(Loader.Scene.Ruins);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
