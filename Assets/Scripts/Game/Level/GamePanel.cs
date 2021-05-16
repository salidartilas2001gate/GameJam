using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private Image _playerImage;
    [SerializeField] private Image _enemyImage;
    private AudioSource _audioSource;
    private Vector3 _movePointPlayer;
    private Vector3 _movePointEnemy;

    private void Start()
    {
        //this.gameObject.SetActive(false);
    }
    public void Constructor(Result result)
    {
        this.gameObject.SetActive(true);
        _playerImage.sprite = result.PlayerSprite;
        _enemyImage.sprite = result.EnemySprite;
        _movePointPlayer = result.MovePlayer;
        _movePointEnemy = result.MoveEnemy;
        //_playerImage.transform.position = result.OffsetsPlayer;
        //_enemyImage.transform.position = result.OffsetsEnemy;

        StartCoroutine(Move(_playerImage.gameObject, _movePointPlayer));
        StartCoroutine(Move(_enemyImage.gameObject, _movePointEnemy));
    }

    private IEnumerator Move(GameObject gameObject, Vector3 position)
    {
        var startPosition = gameObject.transform.position;
        gameObject.transform.DOMoveX(position.x, 1).From(startPosition.x);
        gameObject.transform.DOMoveY(position.x, 1).From(startPosition.x);
        gameObject.transform.DOMoveZ(position.x, 1).From(startPosition.x);
         yield return new WaitForSeconds(1);
        
    }
}
