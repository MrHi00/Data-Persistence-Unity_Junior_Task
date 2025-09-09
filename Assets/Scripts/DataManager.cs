using System.IO;
using UnityEngine;

// Need to creat a separate manager for Data presistance
// Key points: Static Instance needs to be created at the start of Play mode!
public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string Username;
    public string bestUsername;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scenes
    }

    public void SetUsername(string username)
    {
        // Debug.Log(username+ " in SetUsername inside Datamanager");
        Username = username;
    }
    public void SetBestUsername(string username)
    {
        bestUsername = username;
    }
    public void SetBestScore(int score)
    {
        bestScore = score;
    }

    // [System.Serializable] is needed to tell JsonUtility it's a class which can be serialized, which means. It can be transformed to Json format.
    [System.Serializable]
    class SaveData
    {
        public string bestUsername;
        public int bestScore;
    }
    public void SaveBestData(string bestUser, int bestScore)
    {
        SaveData data = new SaveData();
        data.bestUsername = bestUser;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadBestData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestUsername = data.bestUsername;
            bestScore = data.bestScore;
        }
    }
}