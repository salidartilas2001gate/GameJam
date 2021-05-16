using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionOfButtons : MonoBehaviour
{

    public List<OneButone> _buttonsList;
    public OneButone _prefabButton;

    public GameObject _gamePanel;

    public float _timeLife = 1;

    public Color[] _colorSpectr;

    public List<Vector3> _positionSectorButton;

    public event System.Action<bool, Transform, Vector3> OnReturnInfo;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void GenerationButton(string textButtton, int spectr, int maxPower)
    {
        OneButone _instantionSampleButton = Instantiate(_prefabButton, _gamePanel.transform);
        _instantionSampleButton.SetKey(textButtton);
        _instantionSampleButton.SetColor(_colorSpectr[spectr]);
        _instantionSampleButton.SetLife(maxPower/10 + _timeLife);

        bool refrash = true;
        float xButton = 0;
        float yButton = 0;
        int indexButton = 0;
        do
        {
            indexButton = Random.Range(0, _positionSectorButton.Count);
            if(_positionSectorButton[indexButton].z == 0)
            {
                refrash = false;
                xButton = _positionSectorButton[indexButton].x;
                yButton = _positionSectorButton[indexButton].y;
                _positionSectorButton[indexButton] = new Vector3(xButton, yButton, 1);
            }
        } while (refrash);

        xButton += Random.Range(-100, 100) / 100;
        yButton += Random.Range(-100, 100) / 100;
        _instantionSampleButton.transform.position = new Vector3(xButton, yButton, 11);
        _buttonsList.Add(_instantionSampleButton);
        
        StartCoroutine(RemovalFromTheList(_instantionSampleButton, maxPower / 10 + _timeLife, indexButton));
    }

    IEnumerator RemovalFromTheList(OneButone _instantionSampleButton, float life, int indexPosition)
    {
        _instantionSampleButton.OnReturnResult += ddd;
        bool _state = false;
        void ddd(bool state)
        {
            _state = state;
        }
        yield return new WaitForSeconds(life);
        _positionSectorButton[indexPosition] = new Vector3(_positionSectorButton[indexPosition].x, _positionSectorButton[indexPosition].y, 0);
        OnReturnInfo(_state, _gamePanel.transform, _instantionSampleButton.gameObject.transform.position);
        _buttonsList.Remove(_instantionSampleButton);
        Destroy(_instantionSampleButton.gameObject);
        Destroy(_instantionSampleButton);
    }

    public string GetStringList()
    {
        string keyList = "";

        for (int i = 0; i < _buttonsList.Count; i++)
        {
            string keyText = _buttonsList[i].GetComponent<OneButone>().GetKey();

            keyList += keyText;
        }
        return keyList;
    }

    public void pressButton(int indexButton, string textKey)
    {
         _buttonsList[indexButton].PressKey(textKey);
    }

    
}
