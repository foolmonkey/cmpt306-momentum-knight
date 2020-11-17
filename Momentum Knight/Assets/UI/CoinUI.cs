using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    public PlayerManager playerManager;
    public TextMeshProUGUI currentCoinText;

    // Update is called once per frame
    void Update()
    {
        currentCoinText.text = playerManager.currentCoins.ToString();
    }
}
