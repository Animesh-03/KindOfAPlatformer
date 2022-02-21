using System.IO;
using UnityEngine;
using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;

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

        // string json = JsonUtility.ToJson(playerData);

        // File.WriteAllText("./Assets/Misc/Resources/PlayerData/PlayerData.txt",json);

        FileStream dataFile;
        if(File.Exists(Application.persistentDataPath + "/PlayerData.txt"))
        {
            dataFile = File.OpenWrite(Application.persistentDataPath + "/PlayerData.txt");
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(dataFile,playerData);
            dataFile.Close();
        }
        else
        {
            dataFile = File.Create(Application.persistentDataPath + "/PlayerData.txt");
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(dataFile,playerData);
            dataFile.Close();
        }

    }
    //Return a player Data object from the JSON and refreshes the file each call
    public PlayerData GetPlayerData()
    {
        FileStream dataFile;

        if(File.Exists(Application.persistentDataPath + "/PlayerData.txt"))
        {
            dataFile = File.OpenRead(Application.persistentDataPath + "/PlayerData.txt");
            BinaryFormatter bf = new BinaryFormatter();
            PlayerData playerData = bf.Deserialize(dataFile) as PlayerData;
            return playerData;
        }
        else
        {
            return new PlayerData();
        }
    
    }
}
[System.Serializable]
public class PlayerData
{
    public int coins;
    public int levelIndex;
    public int checkpoint;

    public PlayerData()
    {
        coins = 0;
        levelIndex = 1;
        checkpoint = 0;
    }
}
