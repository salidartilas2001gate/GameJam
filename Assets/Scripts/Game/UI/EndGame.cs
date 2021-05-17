using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private AllPattern pattern;
    [SerializeField] private Button _restartGame;
    [SerializeField] private Button _exitMainMenu;
    [SerializeField] private Button _exitGame;
    public event Func<int> GetTime;
    public event Action<int> GameOver;
    public event Action<int> ReturnTime;

    private void Awake()
    {
        _restartGame.OnTabButton += StartGame;
        _exitMainMenu.OnTabButton += ExitMainMenu;
        _exitGame.OnTabButton += ExitGame;
        pattern.EndGame += OpenPanel;
    }
    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void OpenPanel(int score)
    {
        this.gameObject.SetActive(true);
        GameOver(score);
        ReturnTime(GetTime());
    }
    private void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    private void ExitMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    private void ExitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    public int GetMoney()
    {
        return pattern.GetCoin();
    }
}
