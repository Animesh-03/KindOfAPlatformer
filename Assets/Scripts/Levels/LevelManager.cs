using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{   
    public Transform[] spawnAnchors;
    
    [HideInInspector]
    public Transform currentSpawn;
    [HideInInspector]
    public int spawnIndex = 0;
    
    void Start()
    {
        Initialise();
    }

    void Update()
    {
        
    }

    void Initialise()
    {
        PlayerData playerData =  PlayerDataManager.Instance.GetPlayerData();
        spawnIndex = playerData.checkpoint;
        currentSpawn = spawnAnchors[spawnIndex];

        GameObject.FindObjectOfType<Player>().Respawn();
    }

    public void NextSpawn(int number)
    {
        spawnIndex = number;
        currentSpawn = spawnAnchors[spawnIndex];
    }
    
}
