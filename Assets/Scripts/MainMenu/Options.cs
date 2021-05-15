using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] private Slider _audioSlider;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Button _saveOptions;

    private float _soundVolume;
    private float _audioVolume;

    public event Action<float, float> OnSaveOptions;

    
    private void Awake()
    {
        _saveOptions.OnTabButton += SaveOptions;
    }

    private void SaveOptions()
    {
        _soundVolume = _soundSlider.value;
        _audioVolume = _audioSlider.value;
        OnSaveOptions(_soundVolume, _audioVolume);
    }

}
