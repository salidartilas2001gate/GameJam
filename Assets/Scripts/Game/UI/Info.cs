using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    private Text _text;
    [SerializeField] private EndGame pattern;

    private void Awake()
    {
        _text = this.GetComponent<Text>();
        pattern.GameOver += GameOver;
    }

    private void GameOver(int score)
    {
        _text.text = "Вами награблено " + score.ToString() + " $";

    }
}
