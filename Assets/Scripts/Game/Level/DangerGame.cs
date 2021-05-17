using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerGame : MonoBehaviour
{
    [SerializeField] private AllPattern _pattern;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private EndGame _endGame;
    public AudioSource _audioPlayer;
    public AudioClip _traeck;
    public AudioClip _traeckHard;

    public float _minDeltaWave = 1;
    private float _deltaWaveToAmination = 0;
    public float _minLifeKey = 2;

    private char[] _liters = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯ".ToCharArray();

    private AudioPatternPlayer _dateAudio;
    private AudioPattern _refAudioPattern;

    private CollectionOfButtons _refCollectButton;

    public string[] _textButton;
    private char[] _littersOldText = new char[0];
    private int _indexLitter = 0;

    public Text _distance;

    // Start is called before the first frame update
    void Start()
    {
        _dateAudio = GetComponent<AudioPatternPlayer>();
        if (Global._Complexity == 1)
        {
            _minLifeKey = 1;
            _audioPlayer.clip = _traeckHard;
            SelectAudioPattern(GetComponent<CollectionAudioPattern>().GetPatternById(1));
        }
        else
        {
            _minLifeKey = 2;
            _audioPlayer.clip = _traeck;
            SelectAudioPattern(GetComponent<CollectionAudioPattern>().GetPatternById(0));
        }

        _audioPlayer.Play();

        StartCoroutine(RealTimeGenerationSample(0.1f));

        _pauseMenu.PauseAudio += PauseAudio;
        _pauseMenu.PlayAudio += StartAudio;

        _endGame.Pause += PauseAudio;

        _refCollectButton = GetComponent<CollectionOfButtons>();
        _refCollectButton.OnReturnInfo += GenerateMoment;
    }

    private void PauseAudio()
    {
        _audioPlayer.Pause();
    }

    private void StartAudio()
    {
        _audioPlayer.Play();
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

            _distance.text = "До выхода: " + ((_traeck.samples -_audioPlayer.timeSamples)/10000).ToString() + " м";

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

            if(_littersOldText.Length <= _indexLitter)
            {
                _littersOldText = _textButton[Random.Range(0, _textButton.Length)].ToCharArray();
                _indexLitter = 0;
            }

            _refCollectButton.GenerationButton(_littersOldText[_indexLitter].ToString(), spectr);

            _indexLitter++;
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
    private void GenerateMoment(bool key, Transform transform,Vector3 position)
    {
        _pattern.GenerateMoment(key, transform, position);
    }
}
