using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private AllPattern pattern;
    private Text text;
    private float opacity = 1;
    private float timeLife = 1;

    private void Awake()
    {
        text = this.GetComponent<Text>();
        pattern.UpdateUI += UpdateUI;
    }
    private void Start()
    {
        StartCoroutine(Move());
    }

    private void UpdateUI(int score)
    {
        timeLife = 1;
        opacity = 1;
        text.color = new Color(text.color.r, text.color.g, text.color.b, opacity);
        text.text = "+" + score.ToString() + " $";
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        float timeTick = 0.01f;
        float timeLifeMax = timeLife;
        while (timeLife > 0)
        {
            yield return new WaitForSeconds(timeTick);

            timeLife -= timeTick;
            opacity = timeLife / timeLifeMax;

            float scaleImage = 0.01f * (1 - opacity);

            text.color = new Color(text.color.r, text.color.g, text.color.b, opacity);
        }
    }
}
