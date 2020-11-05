using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles loading specific scenes
public static class Loader
{
    public enum Scene{
        MainMenu, Loading, TestPortal, Testv2
    }

    private static Action onLoaderCallback;

    public static void Load(Scene scene){
        SceneManager.LoadScene(Scene.Loading.ToString());

        SceneManager.LoadScene(scene.ToString());
    }

    public static void LoaderCallback(){
        if(onLoaderCallback != null){
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
