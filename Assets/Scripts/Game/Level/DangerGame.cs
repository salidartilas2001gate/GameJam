using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerGame : MonoBehaviour
{
    public AudioSource _audioPlayer;
    public AudioClip _traeck;

    public float _minDeltaWave = 1;
    private float _deltaWaveToAmination = 0;
    public float _minLifeKey = 2;

    private char[] _liters = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯ".ToCharArray();

    private AudioPatternPlayer _dateAudio;
    private AudioPattern _refAudioPattern;

    // Start is called before the first frame update
    void Start()
    {
        _deltaWaveToAmination = _minDeltaWave;
        Global._Treack = _traeck;
        _audioPlayer.clip = Global._Treack;

        _audioPlayer.Play();
        
        _dateAudio = GetComponent<AudioPatternPlayer>();

        SelectAudioPattern(GetComponent<CollectionAudioPattern>().GetPatternById(0));
        StartCoroutine(RealTimeGenerationSample(0.1f));
    }

    IEnumerator RealTimeGenerationSample(float dTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(dTime);
            
            _deltaWaveToAmination -= dTime;

            if (_dateAudio.getLenght() <= 0 && _traeck.samples - 448000 > _audioPlayer.timeSamples)
            {
                SelectAudioPattern(_refAudioPattern.getTags());
            }
            else
            {
                if (_dateAudio.isLife(dTime))
                {
                    GenericDangetColor(_dateAudio.getSpectr(), 2);
                }
            }

            if (!_audioPlayer.isPlaying) ToEndWave();
        }
    }

    public void ToEndWave()
    {
        Debug.Log("END");
    }

    private void GenericDangetColor(int spectr, int maxPower)
    {
        if (_deltaWaveToAmination <= 0)
        {
            _deltaWaveToAmination = _minDeltaWave;
            GetComponent<CollectionOfButtons>()._timeLife = _minLifeKey;
            GetComponent<CollectionOfButtons>().GenerationButton(_liters[Random.Range(0, _liters.Length)].ToString(), spectr, maxPower);
        }
    }

    private void SelectAudioPattern(AudioPattern aPattern)
    {
        _refAudioPattern = aPattern;
        _dateAudio.SetPattern(_refAudioPattern);
        _dateAudio.Refrash();
    }
}
