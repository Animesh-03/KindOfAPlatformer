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

    //Writes the player in JSON from the playerData object
    public void WritePlayerData(int coins, int levelIndex, int checkpoint)
    {
        PlayerData playerData = new PlayerData();
        
        playerData.checkpoint = checkpoint;
        playerData.coins = coins;
        playerData.levelIndex = levelIndex;

        string json = JsonUtility.ToJson(playerData);

        File.WriteAllText("./Assets/Misc/PlayerData/PlayerData.txt",json);

    }
    //Return a player Data object from the JSON and refreshes the file each call
    public PlayerData GetPlayerData()
    {
        AssetDatabase.ImportAsset("Assets/Misc/PlayerData/PlayerData.txt");
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
