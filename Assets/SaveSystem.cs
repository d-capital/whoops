using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using YG;


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
            if (YandexGame.SDKEnabled) 
            {
                LoadSaveCloud();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += LoadSaveCloud;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= LoadSaveCloud;
    }

    public void SavePlayer()
    {
        int sceneIndex = levelDictinonary.FirstOrDefault(x => x.Value == SceneManager.GetActiveScene().name).Key;
        string nextSceneName = levelDictinonary[sceneIndex];
        playerData.CurrentLevelName = nextSceneName;
        playerData.MajorState = FindObjectsByType<CharacterDialogue>(FindObjectsSortMode.None).First(x => x.CharacterName == "Major").currenDialogueState;
        MySave();
    }

    public void LoadPlayerData()
    {
        LoadSaveCloud();
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

    public void LoadSaveCloud()
    {
        playerData.CurrentLevelName = YandexGame.savesData.CurrentLevelName;
        playerData.MajorState = YandexGame.savesData.MajorState;
    }

    public void MySave()
    {
        YandexGame.savesData.CurrentLevelName = playerData.CurrentLevelName;
        YandexGame.savesData.MajorState = playerData.MajorState;
        YandexGame.SaveProgress();
    }
}