using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerGame : MonoBehaviour
{
    private int[] _bufferDamageLeft = new int[7];
    private int[] _bufferDamageRight = new int[7];
    private int[] _allDangers = new int[7];
    public float _livelHardMuzic = 0.3f;
    public float _livelHardBuffer = 0.3f;
    public float _livelHardSpeed = 1f;
    public static Vector2 SizeCamera { get; private set; }

    private float[] _deltaLeftTime = new float[7];
    private float[] _deltaRightTime = new float[7];

    public AudioSource _audioPeer;
    public AudioSource _audioPlayer;

    public AudioClip _traeck;

    public float _minDeltaWave = 1;
    private float _deltaWaveToAmination = 0;

    public float _minLifeKey = 2;
    private float _deltaLifeKey = 0;

    private char[] _liters = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯ".ToCharArray();

    public Text _debagerText;

    // Start is called before the first frame update
    void Start()
    {
        _deltaLifeKey = _minLifeKey;
        _deltaWaveToAmination = _minDeltaWave;
        Global._Treack = _traeck;
        _audioPeer.clip = Global._Treack;
        _audioPlayer.clip = Global._Treack;

        _audioPeer.Play();
        Invoke("InvokePlaySound", _minDeltaWave);

        //_livelHardMuzic = 0.9f - Global._Complexity / 1.5f;
        //_livelHardBuffer = 1.1f - Global._Complexity / 1.5f;
        //_livelHardSpeed = 1.1f - Mathf.Pow(Global._Complexity, 2) / 2f;
        for (int i = 0; i < 7; i++)
        {
            _allDangers[i] = 0;
            _deltaLeftTime[i] = 0;
            _deltaRightTime[i] = 0;
        }

        var cam = Camera.main;
        SizeCamera = new Vector2(cam.orthographicSize * cam.aspect, cam.orthographicSize);
    }

    private void InvokePlaySound()
    {
        _audioPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float dTime = Time.deltaTime;

        _deltaWaveToAmination -= dTime;
        _deltaLifeKey -= dTime;

        string line = "";

        for (int i = 0; i < 7; i++)
        {
            /*
            if (AudioPeer._bandBufferRight[i] - AudioPeer._freqBandRight[i] > _livelHardBuffer)
            {
                _bufferDamageRight[i]++;
            }
            else
            {
                if (_bufferDamageRight[i] > 5)
                {
                    GenericDangetColor(i, _bufferDamageRight[i], 0);
                }
                _bufferDamageRight[i] = 0;
            }
            */

            if (AudioPeer._bandBufferLeft[i] - AudioPeer._freqBandLeft[i] > _livelHardBuffer)
            {
                _bufferDamageLeft[i]++;
            }
            else
            {
                if (_bufferDamageLeft[i] > 30)
                {
                    GenericDangetColor(i, _bufferDamageLeft[i]);
                }
                _bufferDamageLeft[i] = 0;
            }
            line += _bufferDamageLeft[i] + "\n";
        }
        _debagerText.GetComponent<Text>().text = line;
    }

    public void ToEndWave()
    {
        Invoke("DestroyParticalWave", 1);
    }

    private void DestroyParticalWave()
    {

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

}
