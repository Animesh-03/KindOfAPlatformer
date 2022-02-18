using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{   
    public Transform[] spawnAnchors;
    
    // [HideInInspector]
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
        spawnIndex = 0;
        currentSpawn = spawnAnchors[spawnIndex];
    }

    public void NextSpawn(int number)
    {
        spawnIndex = number;
        currentSpawn = spawnAnchors[spawnIndex];
    }
    
}
