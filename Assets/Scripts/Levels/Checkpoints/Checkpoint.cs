using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int spawnNumber;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if(GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().spawnIndex < spawnNumber)  // If new checkpoint is after the older one then set new spawn
            {
                GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().NextSpawn(spawnNumber);
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("Checkpoint");
                Debug.Log("Changed Spawn"); 
            }
        }
        
        
    }
}
