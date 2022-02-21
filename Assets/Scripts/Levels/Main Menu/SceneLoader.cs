using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    private PlayerData playerData;
    public int coins;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);

    }

    void Update()
    {   
        //Return to main menu
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0,LoadSceneMode.Single);
        }
    }
    //Loads the next level and writes the player data
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1,LoadSceneMode.Single);
        var playerData = PlayerDataManager.Instance.GetPlayerData();
        PlayerDataManager.Instance.WritePlayerData(playerData.coins,SceneManager.GetActiveScene().buildIndex + 1,0);
    }
    //Loads the specified level
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index,LoadSceneMode.Single);
        PlayerDataManager.Instance.WritePlayerData(0,index,0);
    }
    //Loads level 1 and rewrites the playerData
    public void NewGame()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
        PlayerDataManager.Instance.WritePlayerData(0,1,0);
    }
    //Gets the data for the last saved level and loads it
    public void ContinueGame()
    {
        playerData =  PlayerDataManager.Instance.GetPlayerData();
        SceneManager.LoadScene(playerData.levelIndex,LoadSceneMode.Single);
    }
}
