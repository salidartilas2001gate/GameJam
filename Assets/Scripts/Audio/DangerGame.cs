using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerGame : MonoBehaviour
{

    public GameObject _preFab;
    private float _radiusDunger = 2;
    public Color[] _colors;
    private float _andl = 0;
    private float[] _bufferDamageLeft = new float[7];
    private float[] _bufferDamageRight = new float[7];
    private int[] _allDangers = new int[7];
    public float _livelHardMuzic = 0.3f;
    public float _livelHardBuffer = 0.3f;
    public float _livelHardSpeed = 1f;
    public ParticleSystem _particleSystemWavePrefab;
    private ParticleSystem _particleSystemWave;
    private int _statusPlay = 0;
    private float _timeTotal = 0;
    public GameObject _panelScore;
    public static Vector2 SizeCamera { get; private set; }

    private float[] _deltaLeftTime = new float[7];
    private float[] _deltaRightTime = new float[7];

    public GameObject _fonGame;
    public Sprite[] _allFonGame;

    public AudioSource _audioPeer;

    // Start is called before the first frame update
    void Start()
    {
        _audioPeer.clip = Global._Treack;
        _audioPeer.Play();

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

        if (Global._selectFon != 0)
        {
            _fonGame.GetComponent<Image>().sprite = _allFonGame[Global._selectFon - 1];
            _fonGame.GetComponent<Image>().color = Color.white;
        }
        else {
            _fonGame.GetComponent<Image>().color = Color.black;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_audioPeer.isPlaying)
            _timeTotal += Time.deltaTime;


    }

    public void ToEndWave()
    {
        ParticleSystem _particleSystemWave = (ParticleSystem)Instantiate(_particleSystemWavePrefab);
        Invoke("DestroyParticalWave", 1);
        _statusPlay = 1;
    }

    private void DestroyParticalWave()
    {
        Destroy(_particleSystemWave);
    }

}
