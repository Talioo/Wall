using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    [SerializeField] private GameObject resultWindow;
    [SerializeField] private Text resultText;
    [SerializeField] private Button restartBtn;

    void Start()
    {
        resultWindow.SetActive(false);
        restartBtn.onClick.AddListener(Restart);
        GameManager.Instance.GameOver += GameOver;

    }
    private void GameOver(bool win)
    {
        resultWindow.SetActive(true);
        resultText.text = win ? Const.WinText : Const.LoseText;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
