using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject coinTextObj;

    private TMPro.TextMeshProUGUI coinText;

    public void ChangeCoinText(int coins)
    {
        coinText.text = "x" + coins;
    }

    void Start()
    {
        coinText = coinTextObj.GetComponent<TMPro.TextMeshProUGUI>(); 
        Initialise();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Gets the player data and sets the coin text
    void Initialise()
    {
        ChangeCoinText(PlayerDataManager.Instance.GetPlayerData().coins);
    }
}
