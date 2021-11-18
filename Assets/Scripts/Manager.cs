using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public string previousPleyer;
    public string currentPlayer;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public string SetHighScore()
    {
        string score = "Best Score : " + previousPleyer + " : " + highScore;
        return score;
    }

    [System.Serializable]
    class SaveData
    {
        public string previousPlayer;
        public int highScore;
    }

    public void UpdateScore(int newScore)
    {
        SaveData data = new SaveData();
        data.previousPlayer = currentPlayer;
        data.highScore = newScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            previousPleyer = data.previousPlayer;
            highScore = data.highScore;
        }
    }

}
