using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = this.GetComponent<Text>();
        _text.text = Global.Coin.ToString() + " $";
    }
}
