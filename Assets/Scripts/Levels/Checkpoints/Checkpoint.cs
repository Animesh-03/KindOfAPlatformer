using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    public int spawnNumber;
    public GameObject tutGhost;
    private LevelManager levelManager;
    public bool finalCheckpoint;

    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

        //Disable all the tutorial ghosts except the one associated with the initial checkpoint
        if(levelManager.spawnIndex != spawnNumber && tutGhost != null)  
        {
            tutGhost.SetActive(false);
        }
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if(finalCheckpoint)
            {
                if(SceneManager.GetActiveScene().buildIndex - 1  == SceneManager.sceneCountInBuildSettings)
                {
                    SceneLoader.Instance.LoadLevel(0);
                }
                else
                {
                    SceneLoader.Instance.NextLevel();
                }
                
            }
            else
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

                    //Rewrites player data each time a checkpoint is reached
                    PlayerDataManager.Instance.WritePlayerData(playerScript.GetCoins(),SceneManager.GetActiveScene().buildIndex, spawnNumber);

                    Debug.Log("Changed Spawn"); 
                }
            }
        }
    }

    void UpdatePlayerData()
    {

    }

}
