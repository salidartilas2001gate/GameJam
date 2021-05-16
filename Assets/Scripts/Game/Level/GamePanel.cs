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

    public void Constructor(Result result)
    {
        _playerImage.sprite = result.PlayerSprite;
        _enemyImage.sprite = result.EnemySprite;
        _movePointPlayer = _playerImage.gameObject.transform.position + result.MovePlayer;
        _movePointEnemy = _enemyImage.gameObject.transform.position + result.MoveEnemy;
        StartCoroutine(Move(_playerImage.gameObject, _movePointPlayer));
        StartCoroutine(Move(_enemyImage.gameObject, _movePointEnemy));
    }

    private IEnumerator Move(GameObject gameObject, Vector3 position)
    {
        var startPosition = gameObject.transform.position;
        gameObject.transform.DOMoveX(position.x, 1).From(startPosition.x);
        gameObject.transform.DOMoveY(position.y, 1).From(startPosition.y);
         yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
