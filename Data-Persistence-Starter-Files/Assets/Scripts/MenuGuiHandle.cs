using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class MenuGuiHandle : MonoBehaviour
{
    public InputField nameText;
    public Text HighScoreText;

    private void Start()
    {
        LoadGameRank();
        
    }

    public void LoadGameRank()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            HighScoreText.text = $"Best Score - {data.TheBestPlayer}: {data.HighiestScore}";
        }
    }

    public void StartBtn()
    {
        PlayerData.Instance.PlayerName = nameText.text;
        Debug.Log("Player " + nameText.text + " is playing...");
        SceneManager.LoadScene(1);
    }

    public void ResetBtn()
    {
        SaveData data = new SaveData();

        data.TheBestPlayer = "";
        data.HighiestScore = 0;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void QuitBtn()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
