using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    /// <summary>
    /// DataManager.Instance is a static class instance to save/load data.
    /// </summary>
    public static DataManager Instance;

    public string currentName;
    public int currentScore;

    // High score:
    public string highScoreName;
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

        LoadScore();
    }
    [System.Serializable]
    class SaveData
    {
        public string highScoreName;
        public int highScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highScoreName = highScoreName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }
    }





}
