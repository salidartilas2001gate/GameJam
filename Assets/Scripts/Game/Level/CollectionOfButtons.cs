using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionOfButtons : MonoBehaviour
{

    public List<GameObject> _buttonsList;
    public GameObject _prefabButton;

    public float _timeLife = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void generationButton(string textButtton)
    {
        GameObject _instantionSampleButton = (GameObject)Instantiate(_prefabButton);
        _buttonsList.Add(_instantionSampleButton);

        Invoke("DestroyButton", _timeLife);

        //_buttonsList.Remove(_instantionSampleButton, _timeLife);
        Destroy(_instantionSampleButton, _timeLife);
    }

    private void DestroyButton()
    {

    }
}
