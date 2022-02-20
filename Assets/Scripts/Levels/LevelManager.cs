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
    //Gets the player data and sets the checkpoint
    void Initialise()
    {
        PlayerData playerData =  PlayerDataManager.Instance.GetPlayerData();
        if(playerData.checkpoint <= spawnAnchors.Length)
        {
            NextSpawn(playerData.checkpoint);
        }
        else
        {
            NextSpawn(0);
        }
        

        GameObject.FindObjectOfType<Player>().Respawn();
    }

    public void NextSpawn(int number)
    {
        spawnIndex = number;
        currentSpawn = spawnAnchors[spawnIndex];
    }
    
}
