using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public PlayerManager playerManager;
    public GameManager gm;

    // Update is called once per frame
    void Update()
    {
    }
    public void LoadNextLevel()
    {
        playerManager = (PlayerManager)FindObjectOfType(typeof(PlayerManager));
        gm = (GameManager)FindObjectOfType(typeof(GameManager));

        gm.setScore(playerManager.getCoins());
        // keep track of current index
        gm.setPrevMapIndex(SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(LoadLevel(2));
    }

    // Loads the next scene after the score scene was displayed
    public void LoadSceneAfterScore()
    {
        gm = (GameManager)FindObjectOfType(typeof(GameManager));

        StartCoroutine(LoadLevel(gm.getPrevMapIndex() + 1));
    }

    public void LoadSceneAfterGametip()
    {
        gm = (GameManager)FindObjectOfType(typeof(GameManager));
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadSpecificLevel(int level)
    {
        playerManager = (PlayerManager)FindObjectOfType(typeof(PlayerManager));
        gm = (GameManager)FindObjectOfType(typeof(GameManager));
        gm.setScore(playerManager.getCoins());

        StartCoroutine(LoadLevel(level));
    }

    public void LoadFirstLevel()
    {
        gm = (GameManager)FindObjectOfType(typeof(GameManager));
        gm.setPrevMapIndex(4);
        StartCoroutine(LoadLevel(3));
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
