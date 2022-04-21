using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuGuiHandle : MonoBehaviour
{
    public InputField nameText;
    public Text HighScoreText;

    private void Start()
    {
        SaveData data = new SaveData();
        HighScoreText.text = $"Best Score - {data.HighiestScore}: {data.TheBestPlayer}";
    }

    public void StartBtn()
    {
        PlayerData.Instance.PlayerName = nameText.text;
        Debug.Log("Player " + nameText.text + " is playing...");
        SceneManager.LoadScene(1);
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
