using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Result")]
public class Result : ScriptableObject
{
    [SerializeField] private Sprite _playerSprite;
    [SerializeField] private Sprite _enemySprite;
    [SerializeField] private AudioClip _audioResult;
    [SerializeField] private Vector3 _movePlayer;
    [SerializeField] private Vector3 _moveEnemy;

    [SerializeField] private int _coin;
    [SerializeField] private int _damage;

    public Sprite PlayerSprite { get => _playerSprite;}
    public Sprite EnemySprite { get => _enemySprite;}
    public AudioClip AudioResult { get => _audioResult;}
    public Vector3 MovePlayer { get => _movePlayer;}
    public Vector3 MoveEnemy { get => _moveEnemy;}
    public int Coin { get => _coin;}
    public int Damage { get => _damage;}
}
