using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwicher : MonoBehaviour
{
    [SerializeField] private Button _startGame;
    [SerializeField] private Button _info;
    [SerializeField] private Button _creators;
    [SerializeField] private Button _exitGame;

    private void Awake()
    {
        _startGame.OnTabButton += StartGame;
        _info.OnTabButton += Info;
        _creators.OnTabButton += Creators;
        _exitGame.OnTabButton += ExitGame;
    }

    private void StartGame()
    {
        
    }

    private void Info() 
    {

    }

    private void Creators()
    {

    }

    private void ExitGame()
    {

    }
}
