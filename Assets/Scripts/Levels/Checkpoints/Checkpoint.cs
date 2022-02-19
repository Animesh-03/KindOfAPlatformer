using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int spawnNumber;
    public GameObject tutGhost;
    private LevelManager levelManager;

    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

        //Disable all the tutorial ghosts except the one associated with the initial checkpoint
        if(levelManager.spawnIndex != spawnNumber && tutGhost != null)  
        {
            tutGhost.SetActive(false);
            Debug.Log(transform.name);
        }
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if(levelManager.spawnIndex < spawnNumber)  // If new checkpoint is after the older one then set new spawn
            {
                Destroy(levelManager.currentSpawn.GetComponent<Checkpoint>().tutGhost); //Destroys the tut ghost object of previous checkpoint
                levelManager.NextSpawn(spawnNumber);

                if(tutGhost != null)    //Enable the tut ghost of current checkpoint
                {
                    tutGhost.SetActive(true);
                    Debug.Log(tutGhost.name);
                }
                                    
                GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("Checkpoint");  //Play checkpoint sound

                var playerScript = col.gameObject.transform.GetComponent<Player>();
                playerScript.ResetGhost();  //Reset the ghost of the player
                playerScript.diedInCheckpoint = false;

                Debug.Log("Changed Spawn"); 
            }
        }
    }

    void UpdatePlayerData()
    {

    }

}
