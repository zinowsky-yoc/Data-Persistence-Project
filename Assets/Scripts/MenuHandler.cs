using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TMP_InputField nameInput;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.LoadHighscore();
        Debug.Log("load:" + GameManager.Instance.Name);
        nameInput.text = GameManager.Instance.Name;
        scoreText.text = "Best Score: " + GameManager.Instance.Recordholder + " : " + GameManager.Instance.Highscore;
    }

    public void SetHighScore(string name, int score)
    {
        GameManager.Instance.Recordholder = name;
        GameManager.Instance.Highscore = score;
    }

    public void StartNew() {
        GameManager.Instance.Name = nameInput.text;
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void Exit() {
        GameManager.Instance.SaveHighscore();

        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
