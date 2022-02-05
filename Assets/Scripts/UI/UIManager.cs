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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
