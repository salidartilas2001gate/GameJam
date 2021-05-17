using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCliickSource : MonoBehaviour
{
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private AudioClip _audioClick;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = this.GetComponent<AudioSource>();
        for (int i = 0; i < _buttons.Count; i++)
        {
            _buttons[i].PlayAudioClick += PlayAudioClip;
        }
    }

    private void PlayAudioClip()
    {
        _audioSource.PlayOneShot(_audioClick);
    }

}
