using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class ScoreUI : MonoBehaviour
{
    GameManager gameManager;
    public TextMeshProUGUI currentScoreText;
    private void Awake()
    {
        gameManager = (GameManager)FindObjectOfType(typeof(GameManager));
        currentScoreText.text = gameManager.getScore().ToString();
    }
}
