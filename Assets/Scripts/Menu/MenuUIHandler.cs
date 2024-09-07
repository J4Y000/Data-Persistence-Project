using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI nameText;

    private void Start()
    {
        highScoreText.text = "High Score: " + DataManager.Instance.highScoreName + " " + DataManager.Instance.highScore;
        nameText.text = "Current Player: " + DataManager.Instance.currentName;
    }

    public void StoreInput(string inputString)
    {
        DataManager.Instance.currentName = inputString;
        nameText.text = "Current Player: " + DataManager.Instance.currentName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        DataManager.Instance.SaveScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
