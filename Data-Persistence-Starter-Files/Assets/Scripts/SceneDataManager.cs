using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SceneDataManager : MonoBehaviour
{
    public static SceneDataManager instance;

    public string userName;
    public int userScore;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]

    class UserData
    {
        public string uName;
        public int uScore;
    }

    UserData data = new UserData();

    public void SaveName()
    {
        data.uName = userName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/userdata.json", json);
    }

    public void SaveScore()
    {
        data.uScore = userScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/userdata.json", json);
    }

    public string LoadName()
    {
        string path = Application.persistentDataPath + "/userdata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            UserData data = JsonUtility.FromJson<UserData>(json);
 
           return data.uName;
        }
        else
        {
            return null;
        }
    }

    public int LoadScore()
    {
        string path = Application.persistentDataPath + "/userdata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            UserData data = JsonUtility.FromJson<UserData>(json);

            return data.uScore;
        }
        else
        {
            return 0;
        }
    }

    public void ClearFile()
    {
        string path = Application.persistentDataPath + "/userdata.json";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
