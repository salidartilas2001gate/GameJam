using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerGame : MonoBehaviour
{
    [SerializeField] private AllPattern pattern;
    public AudioSource _audioPlayer;
    public AudioClip _traeck;

    public float _minDeltaWave = 1;
    private float _deltaWaveToAmination = 0;
    public float _minLifeKey = 2;

    private char[] _liters = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯ".ToCharArray();

    private AudioPatternPlayer _dateAudio;
    private AudioPattern _refAudioPattern;

    private CollectionOfButtons _refCollectButton;

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

        _refCollectButton = GetComponent<CollectionOfButtons>();
        _refCollectButton.OnReturnInfo += fff;
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
                    GenericDangetColor(_dateAudio.getSpectr());
                }
            }

            if (!_audioPlayer.isPlaying) ToEndWave();
        }
    }

    public void ToEndWave()
    {
        Debug.Log("END");
    }

    private void GenericDangetColor(int spectr)
    {
        if (_deltaWaveToAmination <= 0)
        {
            _deltaWaveToAmination = _minDeltaWave;
            _refCollectButton._timeLife = _minLifeKey;
            _refCollectButton.GenerationButton(_liters[Random.Range(0, _liters.Length)].ToString(), spectr);
        }
    }

    private void SelectAudioPattern(AudioPattern aPattern)
    {
        _refAudioPattern = aPattern;
        _dateAudio.SetPattern(_refAudioPattern);
        _dateAudio.Refrash();
    }

    public void KeyPress(string keyCode)
    {
        char[] listKeyActive = _refCollectButton.GetStringList().ToCharArray();
        if(listKeyActive.Length > 0)
        {
            var indexKey = 0;
            var indexNumber = 0;
            foreach(char keyActive in listKeyActive)
            {
                if(keyActive.ToString() == keyCode)
                {
                    indexKey = indexNumber;
                }
                indexNumber++;
            }

            _refCollectButton.pressButton(indexKey, keyCode);
        }
    }
    private void fff(bool key, Transform transform,Vector3 position)
    {
        pattern.GenerateMoment(key, transform, position);
    }
}
