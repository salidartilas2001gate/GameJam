using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPattern : MonoBehaviour
{
    [SerializeField] private GamePanel _prototypeGamePanel;
    private GamePanel _gamePanel;
    [SerializeField] private Pattern _nextPattern;
    
    

    private void SetNextPattern(Pattern previousPattern)
    {
        _nextPattern = previousPattern.GetPattern();
    }

    public void GenerateMoment(bool result, Transform transformObj, Vector3 position)
    {
        _gamePanel = Instantiate(_prototypeGamePanel, transformObj);
        _gamePanel.transform.position = position;
        _gamePanel.Constructor(_nextPattern.GetResult(result));
        SetNextPattern(_nextPattern);
    }



}
