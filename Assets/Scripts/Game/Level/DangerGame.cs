using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerGame : MonoBehaviour
{
    private float[] _bufferDamageLeft = new float[7];
    private float[] _bufferDamageRight = new float[7];
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

    public float _minDeltaWave = 2;
    private float _delteWaveToAmination = 0;

    // Start is called before the first frame update
    void Start()
    {
        _delteWaveToAmination = _minDeltaWave;
        Global._Treack = _traeck;
        _audioPeer.clip = Global._Treack;
        _audioPlayer.clip = Global._Treack;

        _audioPeer.Play();
        Invoke("InvokePlaySound", _minDeltaWave);

        _livelHardMuzic = 0.9f - Global._Complexity / 1.5f;
        _livelHardBuffer = 1.1f - Global._Complexity / 1.5f;
        _livelHardSpeed = 1.1f - Mathf.Pow(Global._Complexity, 2) / 2f;
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

        _delteWaveToAmination -= dTime;

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
                if (_bufferDamageLeft[i] > 5)
                {
                    GenericDangetColor(i, _bufferDamageLeft[i], 1);
                }
                _bufferDamageLeft[i] = 0;
            }
        }
    }

    public void ToEndWave()
    {
        Invoke("DestroyParticalWave", 1);
    }

    private void DestroyParticalWave()
    {

    }

    private void GenericDangetColor(int i0, float i1, int i2)
    {
        if(_delteWaveToAmination <= 0)
        {
            _delteWaveToAmination = _minDeltaWave;
            Debug.Log(i0);
        }
    }

}
