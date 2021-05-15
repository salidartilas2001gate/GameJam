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

        _textKey.GetComponent<Text>().color = new Color(_textKey.GetComponent<Text>().color.r, _textKey.GetComponent<Text>().color.g, _textKey.GetComponent<Text>().color.b, progress);
        _textKey.fontSize = 100 + (int)(progress * 50);

        _blur.GetComponent<SpriteRenderer>().color = new Color(_blur.GetComponent<SpriteRenderer>().color.r, _blur.GetComponent<SpriteRenderer>().color.g, _blur.GetComponent<SpriteRenderer>().color.b, 1 - progress);
        _blur.transform.position.Scale(new Vector3(256 - (progress * 50), 256 - (progress * 50), 1));
    }

    public bool PressKey(string key)
    {
        _state = 1;
        if(key == _key)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string GetKey()
    {
        if (_state == 0)
        {
            return "";
        }
        else
        {
            return _key;
        }
    }


}
