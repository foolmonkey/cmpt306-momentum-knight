using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    private PlayerManager playerManager;
    public TextMeshProUGUI currentCoinText;

    private void Awake() {
        playerManager = (PlayerManager) FindObjectOfType(typeof(PlayerManager));
    }

    // Update is called once per frame
    void Update()
    {
        currentCoinText.text = playerManager.currentCoins.ToString();
    }
}
