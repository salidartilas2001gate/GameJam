using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISwicher : MonoBehaviour
{
    [SerializeField] private Button _startGame;
    [SerializeField] private Button _info;
    [SerializeField] private Button _creators;
    [SerializeField] private Button _exitGame;

    [SerializeField] private Button _backInfo;
    [SerializeField] private Button _backCreators;
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private GameObject _creatorsPanel;

    private void Awake()
    {
        _startGame.OnTabButton += StartGame;
        _info.OnTabButton += Info;
        _creators.OnTabButton += Creators;
        _exitGame.OnTabButton += ExitGame;
        _backInfo.OnTabButton += BackInfo;
        _backCreators.OnTabButton += BackCreators;

        _infoPanel.SetActive(false);
        _creatorsPanel.SetActive(false);


    }

    private void StartGame()
    {
        Global._Complexity = 0;
        SceneManager.LoadScene(1);
    }

    private void Info() 
    {
        _infoPanel.SetActive(true);
    }

    private void BackInfo()
    {
        _infoPanel.SetActive(false);
    }

    private void Creators()
    {
        _creatorsPanel.SetActive(true);
    }

    private void BackCreators()
    {
        _creatorsPanel.SetActive(false);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
