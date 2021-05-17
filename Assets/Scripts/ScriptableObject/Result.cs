using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Result")]
public class Result : ScriptableObject
{
    [SerializeField] private Sprite _playerSprite;
    [SerializeField] private Sprite _enemySprite;
    [SerializeField] private AudioClip _audioResult;
    [SerializeField] private Vector3 _pointPlayer = new Vector3(1, 1, 11);
    [SerializeField] private Vector3 _movePlayer = new Vector3(0, 0, 1);
    [SerializeField] private float _scalePlayer = 8;
    [SerializeField] private Color _colorPlayer = new Color(0.2f, 0.7f, 0.2f);
    [SerializeField] private Vector3 _pointEnemy = new Vector3(1, 1, 11);
    [SerializeField] private Vector3 _moveEnemy = new Vector3(0, 0, 1);
    [SerializeField] private float _scapeEnemy = 8;
    [SerializeField] private Color _colorEnemy = new Color(0.7f, 0.2f, 0.2f);

    [SerializeField] private int _coin;
    [SerializeField] private int _damage;

    public Sprite PlayerSprite { get => _playerSprite;}
    public Sprite EnemySprite { get => _enemySprite;}
    public AudioClip AudioResult { get => _audioResult;}
    public Vector3 MovePlayer { get => _movePlayer;}
    public Vector3 MoveEnemy { get => _moveEnemy;}
    public Vector3 PointPlayer { get => _pointPlayer; }
    public Vector3 PointEnemy { get => _pointEnemy; }
    public int Coin { get => _coin;}
    public int Damage { get => _damage;}
    public float ScalePlayer { get => _scalePlayer; }
    public float ScaleEnemy { get => _scapeEnemy; }
    public Color ColorPlayer { get => _colorPlayer; }
    public Color ColorEnemy { get => _colorEnemy; }
}
