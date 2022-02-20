using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject levelManager;
    private UIManager uiManager;
    private int coins = 0;
    private Rigidbody2D rb;

    public GhostRecorder ghostPlayerRecorder;
    public GhostRecorder ghostHammerRecorder;
    public bool diedInCheckpoint;


    void Start()
    {
        Application.targetFrameRate = 60;

        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        rb = GetComponent<Rigidbody2D>();
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        coins = PlayerDataManager.Instance.GetPlayerData().coins;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) Respawn();  // If player presses R then respawn
    }

    public void Respawn()
    {
        transform.position = levelManager.GetComponent<LevelManager>().currentSpawn.position;
        rb.velocity = Vector2.zero;
        diedInCheckpoint = true;
        if(GhostPlayer.Instance != null)
        {
            ResetGhost();
            GhostPlayer.Instance.PlayGhost(true);
        }
        
    }

    public void IncreaseCoins()
    {
        coins++;
        uiManager.ChangeCoinText(coins);
    }

    public void SetCoins(int coins)
    {
        this.coins = coins;
        uiManager.ChangeCoinText(coins);
    }

    public void ResetGhost()
    {
        ghostPlayerRecorder.ReplaceWithNewGhost();
        ghostHammerRecorder.ReplaceWithNewGhost();

        GhostPlayer.Instance.StopGhost();
    }

    public LevelManager getLevelManager()
    {
        return levelManager.GetComponent<LevelManager>();
    }

    public int GetCoins()
    {
        return coins;
    }

}
