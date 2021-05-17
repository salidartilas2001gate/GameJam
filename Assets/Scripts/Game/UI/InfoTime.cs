using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTime : MonoBehaviour
{
    private Text _text;
    [SerializeField] private EndGame pattern;

    private void Awake()
    {
        _text = this.GetComponent<Text>();
        pattern.ReturnTime += GameOver;
    }

    private void GameOver(int score)
    {
        _text.text = "До выхода Вам оставалось всего " + ((int)(score / 10000)).ToString() + " метров";

    }
}
