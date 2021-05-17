using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private AllPattern pattern;
    private Text text;

    private void Awake()
    {
        text = this.GetComponent<Text>();
        pattern.UpdateUI += UpdateUI;
    }

    private void UpdateUI(int score)
    {
        text.text = score.ToString();
    }

}
