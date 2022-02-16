using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject levelManager;
    private UIManager uiManager;
    private int coins = 0;
    private Rigidbody2D rb;


    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        rb = GetComponent<Rigidbody2D>();
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) Respawn();  // If player presses R then respawn
    }

    public void Respawn()
    {
        transform.position = levelManager.GetComponent<LevelManager>().currentSpawn.position;
        rb.velocity = Vector2.zero;
    }

    public void IncreaseCoins()
    {
        coins++;
        uiManager.ChangeCoinText(coins);
    }
}
