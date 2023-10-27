using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsCollected : MonoBehaviour
{

    public Player player;

    public TextMeshProUGUI textElement;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void UpdateCoin(int coins) {
        string coinsText = coins.ToString();
        textElement.text = coinsText;
    }

    // Update is called once per frame
    void Update()
    {
        int coins = player.Coins;
        UpdateCoin(coins);
   
    }
}
