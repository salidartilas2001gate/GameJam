using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneButone : MonoBehaviour
{
    private string _key;
    private int _state = 0;

    public Text _textKey;
    public GameObject _blur;

    private Color _color = new Color(1, 1, 1);

    public float _maxLife = 1;
    public float _life = 1;

    public Color _colorOk;
    public Color _colorNo;


    public event Action<bool> OnReturnResult;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Transformstions());
    }

    IEnumerator Transformstions()
    {
        while (_life > 0)
        {
            yield return new WaitForSeconds(0.1f);
            _life -= 0.1f;
            SetProgress(1 - _life / _maxLife);
        }
    }

    public void SetLife(float life)
    {
        _maxLife = life;
        _life = _maxLife;
    }

    public void SetKey(string key)
    {
        _key = key;
        _textKey.GetComponent<Text>().text = _key;
    }

    public void SetColor(Color setColor)
    {
        _color = setColor;
        _textKey.GetComponent<Text>().color = _color;
        _blur.GetComponent<SpriteRenderer>().color = _color;
    }
    
    private void SetProgress(float progress)
    {
        if (progress > 1) progress = 1;

        _textKey.GetComponent<Text>().color = new Color(_textKey.GetComponent<Text>().color.r, _textKey.GetComponent<Text>().color.g, _textKey.GetComponent<Text>().color.b, 0.5f + progress / 2);
        _textKey.fontSize = 100 + (int)(progress * 50);

        _blur.GetComponent<SpriteRenderer>().color = new Color(_blur.GetComponent<SpriteRenderer>().color.r, _blur.GetComponent<SpriteRenderer>().color.g, _blur.GetComponent<SpriteRenderer>().color.b, 1 - progress);
        _blur.transform.position.Scale(new Vector3(220 - (progress * 50) + _maxLife * 10, 220 - (progress * 50) + _maxLife * 10, 1));
    }

    public void PressKey(string key)
    {
        if(key == _key)
        {
            _textKey.GetComponent<Text>().color = _colorOk;
            _state = 1;
            OnReturnResult(true);
        }
        else
        {
            _textKey.GetComponent<Text>().color = _colorNo;
            _state = -1;
            OnReturnResult(false);
        }
    }

    public string GetKey()
    {
        if (_state == 0)
        {
            return _key;
        }
        else
        {
            return "";
        }
    }


}
