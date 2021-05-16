using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPattern : MonoBehaviour
{
    [SerializeField] private Pattern _firstPattern;
    [SerializeField] private GamePanel _prototypeGamePanel;
    private GamePanel _gamePanel;
    private Pattern _nextPattern;
    //private Result _result;

    private void Start()
    {
        //GetResult(_firstPattern);
       // SetNextPattern(_firstPattern);
    }
    
    

    private void SetNextPattern(Pattern previousPattern)
    {
        _nextPattern = previousPattern.GetPattern();
    }

    private void GenerateMoment(Pattern pattern, bool result, Transform transformObj)
    {
        _gamePanel = Instantiate(_prototypeGamePanel, transformObj);
        _gamePanel.Constructor(pattern.GetResult(result));
        SetNextPattern(_nextPattern);
    }



}
