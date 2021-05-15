using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{
    AudioSource _audioSource;
    public static float[] _samplesRight = new float[512];
    public static float[] _samplesLeft = new float[512];
    public static float[] _freqBandLeft = new float[8];
    public static float[] _freqBandRight = new float[8];
    public static float[] _bandBufferLeft = new float[8];
    public static float[] _bandBufferRight = new float[8];
    private float[] _bufferDecreseLeft = new float[8];
    private float[] _bufferDecreseRight = new float[8];
    private bool _spriteWave = true;

    // Start is called before the first frame update
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        for (int g = 0; g < 8; ++g) {
            _freqBandLeft[g] = 0;
            _freqBandRight[g] = 0;
            _bandBufferLeft[g] = 0;
            _bandBufferRight[g] = 0;
            _bufferDecreseLeft[g] = 0;
            _bufferDecreseRight[g] = 0;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        GetSpecrumAudioSource();
        MaceFrequencyBands();
        BandBuffer();

        if (!_audioSource.isPlaying)
        {
            if (_spriteWave)
            {
                _spriteWave = false;
                DangerGame _DangerGame = FindObjectOfType<DangerGame>();
                _DangerGame.ToEndWave();
            }
        }
    }

    private void BandBuffer()
    {
        for (int g = 0; g < 8; ++g)
        {
            if (_freqBandLeft[g] > _bandBufferLeft[g])
            {
                _bandBufferLeft[g] = _freqBandLeft[g];
                _bufferDecreseLeft[g] = 0.005f;
            }
            if (_freqBandLeft[g] < _bandBufferLeft[g])
            {
                _bandBufferLeft[g] -= _bufferDecreseLeft[g];
                _bufferDecreseLeft[g] *= 1.2f;

            }
            if (_freqBandRight[g] > _bandBufferRight[g])
            {
                _bandBufferRight[g] = _freqBandRight[g];
                _bufferDecreseRight[g] = 0.005f;
            }
            if (_freqBandRight[g] < _bandBufferRight[g])
            {
                _bandBufferRight[g] -= _bufferDecreseRight[g];
                _bufferDecreseRight[g] *= 1.2f;

            }
        }
    }
    private void GetSpecrumAudioSource()
    {
        _audioSource.GetSpectrumData(_samplesRight, 0, FFTWindow.Blackman);
        _audioSource.GetSpectrumData(_samplesLeft, 1, FFTWindow.Blackman);
    }
    private void MaceFrequencyBands()
    {
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            float averageLeft = 0;
            float averageRight = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                averageRight += _samplesRight[count] * (count + 1);
                averageLeft += _samplesLeft[count] * (count + 1);
                count++;
            }
            averageRight /= count;
            averageLeft /= count;
            _freqBandRight[i] = Mathf.Pow(averageRight, 0.9f) * 10;
            _freqBandLeft[i] = Mathf.Pow(averageLeft, 0.9f) * 10;
        }
    }
}
