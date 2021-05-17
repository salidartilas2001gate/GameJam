using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprite;
    [SerializeField] private Image _image;
    [SerializeField] private int _health;
    [SerializeField] private int _step;
    [SerializeField] private float opacity = 1;
    [SerializeField] private float timeLife = 1;

    private void Start()
    {
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0);
    }
    public void SetStartHealth(int health)
    {
        _health = health;
        _step = _health / _sprite.Count;
    }

    public void UpdateHP(int health)
    {
        timeLife = 1;
        opacity = 1;
        var updateHealth = _health - health;
        int i = updateHealth / _step;
        _image.sprite = _sprite[i];
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, opacity);
        StartCoroutine(Move(_image));
    }

    private IEnumerator Move(Image image)
    {
        float timeTick = 0.01f;
        float timeLifeMax = timeLife;
        while (timeLife > 0)
        {
            yield return new WaitForSeconds(timeTick);

            timeLife -= timeTick;
            opacity = timeLife / timeLifeMax;
            image.color = new Color(image.color.r, image.color.g, image.color.b, opacity);
        }
    }
}
