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
    public AudioSource _sourceBit;

    // Start is called before the first frame update
    void Start()
    {
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
        _indexDelta -= dTime * 10;
        _lenght -= dTime * 10;

        if (_indexDelta <= 0)
        {
            _indexInterval++;
            if (_intervals.Length >= _indexInterval + 1)
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

    public float getLenght()
    {
        return _lenght;
    }

    public int getSpectr()
    {
        float delta = (_indexDelta <= 1) ? 1 : _indexDelta;
        return (int)(140 / (17 + delta) - 1);
    }
}
