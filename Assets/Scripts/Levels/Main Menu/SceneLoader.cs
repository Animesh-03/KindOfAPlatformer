using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    private PlayerData playerData;
    public int coins;

    // void OnContinue()
    // {
    //     playerData =  PlayerDataManager.Instance.GetPlayerData();

    //     Player p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    //     p.SetCoins(playerData.coins);
    //     p.getLevelManager().NextSpawn(playerData.checkpoint);
    //     Debug.Log("working");
    // }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);

    }
    
    void Start()
    {
        // OnContinue();
    }

   
    void Update()
    {
        
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index,LoadSceneMode.Single);
        PlayerDataManager.Instance.WritePlayerData(0,index,0);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
        PlayerDataManager.Instance.WritePlayerData(0,1,0);
    }

    public void ContinueGame()
    {
        playerData =  PlayerDataManager.Instance.GetPlayerData();

        Debug.Log(playerData.levelIndex);

        SceneManager.LoadScene(playerData.levelIndex,LoadSceneMode.Single);
    }
}
