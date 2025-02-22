using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;


public class SaveSystem : MonoBehaviour
{
    public PlayerData playerData;

    public static SaveSystem Instance;

    public Dictionary<int, string> levelDictinonary = new Dictionary<int, string>(){
        {0,"SampleScene"},
        {1,"Level2"},
        {2,"Level3"},
        {3,"Level4"},
        {4,"Level5"},
        {5,"Level6"},
        {6,"Level7"}
    };

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SavePlayer()
    {
        int sceneIndex = levelDictinonary.FirstOrDefault(x => x.Value == SceneManager.GetActiveScene().name).Key;
        string nextSceneName = levelDictinonary[sceneIndex];
        playerData.CurrentLevelName = nextSceneName;
        playerData.MajorState = FindObjectsByType<CharacterDialogue>(FindObjectsSortMode.None).First(x => x.CharacterName == "Major").currenDialogueState;
    }
    public void SaveToFile()
    {
        string path = Application.persistentDataPath + "/player.fun";
        PlayerData data = playerData;
        string json = JsonConvert.SerializeObject(data);
        File.WriteAllText(path, json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/player.fun";
        Debug.Log(path);
        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate,
                                                        FileAccess.ReadWrite,
                                                        FileShare.ReadWrite);
            stream.Dispose();
            var fileContents = File.ReadAllText(path);
            PlayerData pd = JsonConvert.DeserializeObject<PlayerData>(fileContents);
            playerData = pd;
            stream.Dispose();
            FindObjectsByType<CharacterDialogue>(FindObjectsSortMode.None).First(x => x.CharacterName == "Major").currenDialogueState = playerData.MajorState;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
        }
    }

    public string GetNextLevelName(string currentLevelName)
    {
        int currentLevelIndex = levelDictinonary.First(x => x.Value == currentLevelName).Key;
        int nextLevelIndex = currentLevelIndex + 1;
        if (nextLevelIndex > levelDictinonary.Count)
        {
            return "MainMenu";
        }
        else
        {
            string nextLevelName = levelDictinonary[nextLevelIndex];
            return nextLevelName;
        }
    }
}