using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPattern : MonoBehaviour
{
    [SerializeField] private GamePanel _prototypeGamePanel;
    [SerializeField] private Pattern _nextPattern;
    private GamePanel _gamePanel;
    [SerializeField] private int _score;
    [SerializeField] private int _Health;

    public event Action<int> UpdateUI;
    public event Action EndGame;


    private void SetNextPattern(Pattern previousPattern)
    {
        _nextPattern = previousPattern.GetPattern();
    }

    public void GenerateMoment(bool result, Transform transformObj, Vector3 position)
    {
        _gamePanel = Instantiate(_prototypeGamePanel, transformObj);
        _gamePanel.transform.position = position;
        _gamePanel.Constructor(_nextPattern.GetResult(result));
        if(_score < 0)
        {
            _score = 0;
        }
        else
        {
            _score += _gamePanel.GetCoin();
        }
        UpdateUI(_score);
        if (_Health- _gamePanel.GetDamage()>0)
        {
            _Health -= _gamePanel.GetDamage();
        }
        else
        {
            _Health = 0;
            EndGame();
            Time.timeScale = 0;
        }
        SetNextPattern(_nextPattern);
        Debug.Log(_score);
        Debug.Log(_Health);
    }



}
