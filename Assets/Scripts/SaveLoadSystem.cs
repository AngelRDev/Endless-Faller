using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
class ScoreData
{
    public int highscore;
}

public class SaveLoadSystem : MonoBehaviour
{
    //Path where data file will be stored
    string filePath;

    void Awake()
    {
        filePath = Path.Combine(Application.dataPath, "savedata.dat");
    }

    // Saves highscore
    public void SavePlayerData(int highScore)
    {
        Stream stream = new FileStream(filePath, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        ScoreData data = new ScoreData();
        data.highscore = highScore;
        binaryFormatter.Serialize(stream, data);
        stream.Close();
    }

    public int LoadPlayerData()
    {
        // If there is a previous save, load its highscore
        if (File.Exists(filePath))
        {
            Stream stream = new FileStream(filePath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            ScoreData data = (ScoreData)binaryFormatter.Deserialize(stream);
            stream.Close();
            return data.highscore;
        }
        // If there is no savefile doesn't exists, saves a new one with highscore = 0
        else
        {
            SavePlayerData(0);
            return 0;
        }
    }
}