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

    private int _damage;
    private int _coin;

    public void Constructor(Result result)
    {
        _playerImage.sprite = result.PlayerSprite;
        _enemyImage.sprite = result.EnemySprite;

        _playerImage.gameObject.transform.position = result.PointPlayer;
        _enemyImage.gameObject.transform.position = result.PointEnemy;

        _movePointPlayer = _playerImage.gameObject.transform.position + result.MovePlayer;
        _movePointEnemy = _enemyImage.gameObject.transform.position + result.MoveEnemy;

        _audioSource.PlayOneShot(result.AudioResult);
        _damage = result.Damage;
        _coin = result.Coin;
        StartCoroutine(Move(_playerImage.gameObject, _movePointPlayer, timeLife, _playerImage, result.ScalePlayer, result.ColorPlayer));
        StartCoroutine(Move(_enemyImage.gameObject, _movePointEnemy, timeLife, _enemyImage, result.ScaleEnemy, result.ColorEnemy));
         
    }

    public int GetDamage()
    {
        return _damage;
    }

    public int GetCoin()
    {
        return _coin;
    }

    private IEnumerator Move(GameObject gameObject, Vector3 position, float timeLife, Image imageObject, float reScale, Color colorImg)
    {
        float timeTick = 0.01f;
        float timeLifeMax = timeLife;

        var startPosition = gameObject.transform.position;

        gameObject.transform.DOMoveX(position.x, timeLife).From(startPosition.x);
        gameObject.transform.DOMoveY(position.y, timeLife).From(startPosition.y);
        gameObject.transform.DOMoveZ(position.z, timeLife).From(startPosition.z);

        imageObject.gameObject.transform.localScale = new Vector3(imageObject.gameObject.transform.localScale.x * reScale, imageObject.gameObject.transform.localScale.y * reScale, 1);
        imageObject.color = colorImg;

        while (timeLife > 0)
        {
            yield return new WaitForSeconds(timeTick);

            timeLife -= timeTick;
            opacity = timeLife / timeLifeMax;

            float scaleImage = 0.01f * (1 - opacity);

            imageObject.color = new Color(imageObject.color.r, imageObject.color.g, imageObject.color.b, opacity);
            imageObject.gameObject.transform.localScale = new Vector3(imageObject.gameObject.transform.localScale.x + scaleImage, imageObject.gameObject.transform.localScale.y + scaleImage, 1);
        }

        Destroy(this.gameObject);
    }
}
