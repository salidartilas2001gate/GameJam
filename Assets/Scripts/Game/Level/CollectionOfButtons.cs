using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionOfButtons : MonoBehaviour
{

    public List<GameObject> _buttonsList;
    public GameObject _prefabButton;

    public GameObject _gamePanel;

    public float _timeLife = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void GenerationButton(string textButtton)
    {
        GameObject _instantionSampleButton = (GameObject)Instantiate(_prefabButton, _gamePanel.transform);
        _instantionSampleButton.GetComponent<OneButone>().SetKey(textButtton);
        _instantionSampleButton.GetComponent<OneButone>().SetColor(new Color(1, 0.5f, 1));
        _instantionSampleButton.transform.position = new Vector3(2, 2, 0);
        _buttonsList.Add(_instantionSampleButton);

        StartCoroutine(RemovalFromTheList(_instantionSampleButton));
    }

    IEnumerator RemovalFromTheList(GameObject _instantionSampleButton)
    {
        yield return new WaitForSeconds(_timeLife);
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
