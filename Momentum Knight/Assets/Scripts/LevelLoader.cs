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
        gm.setScore(playerManager.getCoins());
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadSpecificLevel(int level)
    {
        playerManager = (PlayerManager)FindObjectOfType(typeof(PlayerManager));
        gm.setScore(playerManager.getCoins());
        StartCoroutine(LoadLevel(level));
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
