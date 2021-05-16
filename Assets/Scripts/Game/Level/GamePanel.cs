using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private Image _playerImage;
    [SerializeField] private Image _enemyImage;

    public AudioSource _audioSource;
    private Vector3 _movePointPlayer;
    private Vector3 _movePointEnemy;

    private float opacity = 1;
    private float timeLife = 1;

    public void Constructor(Result result)
    {
        _playerImage.sprite = result.PlayerSprite;
        _enemyImage.sprite = result.EnemySprite;

        _movePointPlayer = _playerImage.gameObject.transform.position + result.MovePlayer;
        _movePointEnemy = _enemyImage.gameObject.transform.position + result.MoveEnemy;

        _audioSource.PlayOneShot(result.AudioResult);

        StartCoroutine(Move(_playerImage.gameObject, _movePointPlayer, timeLife));
        StartCoroutine(Move(_enemyImage.gameObject, _movePointEnemy, timeLife));
    }

    private IEnumerator Move(GameObject gameObject, Vector3 position, float timeLife)
    {
        float timeTick = 0.01f;
        float timeLifeMax = timeLife;

        var startPosition = gameObject.transform.position;

        gameObject.transform.DOMoveX(position.x, timeLife).From(startPosition.x);
        gameObject.transform.DOMoveY(position.y, timeLife).From(startPosition.y);
        gameObject.transform.DOMoveZ(position.z, timeLife).From(startPosition.z);

        while (timeLife > 0)
        {
            yield return new WaitForSeconds(timeTick);

            timeLife -= timeTick;
            opacity = timeLife / timeLifeMax;

            float scaleImage = 0.01f * (1 - opacity);

            _playerImage.color = new Color(_playerImage.color.r, _playerImage.color.g, _playerImage.color.b, opacity);
            _playerImage.gameObject.transform.localScale = new Vector3(_playerImage.gameObject.transform.localScale.x + scaleImage, _playerImage.gameObject.transform.localScale.y + scaleImage, 1);

            _enemyImage.color = new Color(_enemyImage.color.r, _enemyImage.color.g, _enemyImage.color.b, opacity);
            _enemyImage.gameObject.transform.localScale = new Vector3(_enemyImage.gameObject.transform.localScale.x + scaleImage, _enemyImage.gameObject.transform.localScale.y + scaleImage, 1);
        }

        Destroy(this.gameObject);
    }
}
