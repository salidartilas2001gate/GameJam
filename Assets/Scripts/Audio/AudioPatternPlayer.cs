using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPatternPlayer : MonoBehaviour
{
    private float _indexDelta;
    private float _lenght;

    private int _indexInterval;

    private int[] _intervals;

    private AudioClip _audioBit;
    private AudioSource _sourceBit;

    // Start is called before the first frame update
    void Start()
    {
        _sourceBit = new AudioSource();
    }

    public void Refrash()
    {
        _indexInterval = 0;
        _indexDelta = GetDeltaInterval(_indexInterval);
    }

    public void SetPattern(AudioPattern audioP)
    {
        _intervals = audioP.getIntervals();
        _audioBit = audioP.getAudioBit();
        _lenght = audioP.getLenght();
    }

    private int GetDeltaInterval(int indexInterval)
    {
        return _intervals[indexInterval];
    }

    public bool isLife(float dTime)
    {
        Debug.Log(_indexDelta);

        _indexDelta -= dTime;
        _lenght -= dTime;

        if (_indexDelta <= 0)
        {
            _indexInterval++;
            if (_intervals.Length <= _indexInterval)
            {
                _indexDelta = GetDeltaInterval(_indexInterval);
            }
            else
            {
                _indexDelta = 999999;
            }
            _sourceBit.clip = _audioBit;
            _sourceBit.Play();

            return true;
        }

        return false;
    }
}
