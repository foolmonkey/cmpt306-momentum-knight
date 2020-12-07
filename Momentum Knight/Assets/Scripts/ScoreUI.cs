using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class ScoreUI : MonoBehaviour
{
    GameManager gameManager;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI totalScoreText;

    private void Awake()
    {
        gameManager = (GameManager)FindObjectOfType(typeof(GameManager));
        if (currentScoreText)
        {
            currentScoreText.text = gameManager.getScore().ToString();
        }

        if (totalScoreText)
        {
            totalScoreText.text = gameManager.getTotalScore().ToString();
        }
    }
}
