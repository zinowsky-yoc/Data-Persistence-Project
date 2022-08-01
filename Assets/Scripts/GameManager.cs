using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string Name;
    public int SessionHighscore;
    public string Recordholder;
    public int Highscore;

    void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData {
        public string Recordholder;
        public int Highscore;
    }

    public void SaveHighscore() {
        SaveData data = new SaveData();
        data.Recordholder = Recordholder;
        data.Highscore = Highscore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/svfile.json", json); 
    }

    public void LoadHighscore() {
        string path = Application.persistentDataPath + "/svfile.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Recordholder = data.Recordholder;
            Highscore = data.Highscore;
        }
    }
}
