using System.IO;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager  Instance;
    public TextAsset playerData;

    void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void WritePlayerData(int coins, int levelIndex, int checkpoint)
    {
        PlayerData playerData = new PlayerData();
        
        playerData.checkpoint = checkpoint;
        playerData.coins = coins;
        playerData.levelIndex = levelIndex;

        string json = JsonUtility.ToJson(playerData);

        File.WriteAllText("./Assets/Misc/PlayerData/PlayerData.txt",json);

    }

    public PlayerData GetPlayerData()
    {
        AssetDatabase.Refresh();
        return JsonUtility.FromJson<PlayerData>(playerData.text);
    }
}
[System.Serializable]
public class PlayerData
{
    public int coins;
    public int levelIndex;
    public int checkpoint;
}
