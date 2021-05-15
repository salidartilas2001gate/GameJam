using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionOfButtons : MonoBehaviour
{

    public List<GameObject> _buttonsList;
    public GameObject _prefabButton;

    public GameObject _gamePanel;

    public float _timeLife = 1;

    public Color[] _colorSpectr;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void GenerationButton(string textButtton, int spectr, int maxPower)
    {
        GameObject _instantionSampleButton = (GameObject)Instantiate(_prefabButton, _gamePanel.transform);
        _instantionSampleButton.GetComponent<OneButone>().SetKey(textButtton);
        _instantionSampleButton.GetComponent<OneButone>().SetColor(_colorSpectr[spectr]);
        _instantionSampleButton.GetComponent<OneButone>().SetLife(maxPower/10 + _timeLife);
        float x = Random.Range(-100, 100) / 13;
        float y = Random.Range(-100, 100) / 25;
        _instantionSampleButton.transform.position = new Vector3(x, y, 11);
        _buttonsList.Add(_instantionSampleButton);

        StartCoroutine(RemovalFromTheList(_instantionSampleButton, maxPower / 10 + _timeLife));
    }

    IEnumerator RemovalFromTheList(GameObject _instantionSampleButton, float life)
    {
        yield return new WaitForSeconds(life);
        //yield return new WaitForSeconds(_timeLife);
        _buttonsList.Remove(_instantionSampleButton);
        Destroy(_instantionSampleButton);
    }

    public string[] GetStringList()
    {
        string[] keyList = new string[0];

        for (int i = 0; i < _buttonsList.Count; i++)
        {
            keyList.SetValue(_buttonsList[i].GetComponent<OneButone>().GetKey(), i);
        }

        return keyList;
    }
}
