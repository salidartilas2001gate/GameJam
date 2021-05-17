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
    [SerializeField] private int _health;
    [SerializeField] private HealthIndicator _healthIndicator;
    public event Action<int> UpdateUI;
    public event Action<int> EndGame;

    private void Start()
    {
        _healthIndicator.SetStartHealth(_health);
    }

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
        else if (_gamePanel.GetCoin() == 0)
        {

        }
        else
        {
            _score += _gamePanel.GetCoin();
            UpdateUI(_gamePanel.GetCoin());
        }
        if (_health - _gamePanel.GetDamage()>0)
        {
            _health -= _gamePanel.GetDamage();
            if (_gamePanel.GetDamage()!>0)
            {
                _healthIndicator.UpdateHP(_health);
            }

        }
        else
        {
            _health = 0;
            EndGame(_score);
            Time.timeScale = 0;
        }
        SetNextPattern(_nextPattern);
    }

    public int GetCoin() 
    {
        return _score;
    }



}
